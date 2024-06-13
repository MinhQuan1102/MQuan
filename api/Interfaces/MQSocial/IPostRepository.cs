using api.DTOModels.MQSocial;
using api.Entities.MQSocial;

namespace api.Interfaces.MQSocial
{
    public interface IPostRepository
    {
        void CreatePost(Post post);
        IEnumerable<PostDTO> GetPostsOfUser(int userId);
        Task<Post> GetPostById(int postId);
        Task<PostDTO> GetPostDTOById(int postId);
    }
}
