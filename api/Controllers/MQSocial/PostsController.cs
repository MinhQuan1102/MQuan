using api.DTOModels.MQSocial;
using api.Entities.MQSocial;
using api.Extensions;
using api.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.MQSocial
{
    [Authorize]
    public class PostsController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PostsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreatePost(CreatePostDTO postDTO)
        {
            var userId = User.GetUserId();
            var user = await _unitOfWork.UserRepository.GetUserByIdAsync(userId);

            if (user == null)
            {
                return Unauthorized();
            }

            var post = new Post
            {
                Content = postDTO.Content,
                UserId = userId,
                User = user,
            };

            _unitOfWork.PostRepository.CreatePost(post);
            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<PostDTO>(post));
            return BadRequest("Failed to create post");
        }

        [HttpGet("{userId}")]
        public ActionResult<PostDTO> GetPostsOfUser(int userId)
        {
            var posts = _unitOfWork.PostRepository.GetPostsOfUser(userId);

            return Ok(posts);
        }


        [HttpPost("react/{postId}")]
        public async Task<ActionResult> ReactPost([FromRoute]int postId, [FromBody] ReactionDTO reactionDTO)
        {
            var userId = User.GetUserId();
            var post = await _unitOfWork.PostRepository.GetPostById(postId);
            if (post == null) return NotFound();

            if (post.Reactions.Any(r => r.UserId == userId))
            {
                post.Reactions.RemoveAll(r => r.UserId == userId);
                post.TotalReactions--;
            }
            else
            {
                var postReaction = new PostReaction
                {
                    Type = reactionDTO.type,
                    UserId = userId,
                    PostId = postId
                };

                post.Reactions.Add(postReaction);
                post.TotalReactions++;
            }

            if (await _unitOfWork.Complete()) return Ok();
            return BadRequest("Failed to react post");
        }
    }
}
