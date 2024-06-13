using api.Entities.MQSocial;

namespace api.DTOModels.MQSocial
{
    public class PostDTO
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public int? UserId { get; set; }
        public int? GroupId { get; set; }
        public int? SharedPostId { get; set; }
        public int? TotalReactions { get; set; }
        public List<PostReactionDTO> Reactions { get; set; } = new();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
