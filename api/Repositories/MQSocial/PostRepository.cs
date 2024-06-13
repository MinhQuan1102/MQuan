using api.Data;
using api.DTOModels.MQSocial;
using api.Entities.MQSocial;
using api.Interfaces.MQSocial;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories.MQSocial
{
    public class PostRepository : IPostRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public PostRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void CreatePost(Post post)
        {
            _context.Posts.Add(post);
        }

        public async Task<Post> GetPostById(int postId)
        {
            var post = await _context.Posts
                .Where(x => x.Id == postId)
                .Include(x => x.Reactions)
                .FirstOrDefaultAsync();

            if (post == null)
            {
                return null;
            }

            return post;
        }

        public async Task<PostDTO> GetPostDTOById(int postId)
        {
            var post = await _context.Posts
                .Where(x => x.Id == postId)
                .ProjectTo<PostDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            if (post == null)
            {
                return null;
            }

            return post;
        }

        public IEnumerable<PostDTO> GetPostsOfUser(int id)
        {
            return _context.Posts
                .Where(
                    p => p.UserId == id
                )
                .OrderBy(p => p.CreatedAt)
                .Select(p => new PostDTO
                {
                    Id = p.Id,
                    Content = p.Content,
                    UserId = p.UserId,
                    GroupId = p.GroupId,
                    SharedPostId = p.SharedPostId,
                    TotalReactions = p.TotalReactions,
                    Reactions = p.Reactions.Select(r => new PostReactionDTO
                    {
                        UserId = r.UserId,
                        Type = r.Type,
                    }).ToList(),
                    CreatedAt = p.CreatedAt,
                    UpdatedAt = p.UpdatedAt
                });
        }
    }
}
