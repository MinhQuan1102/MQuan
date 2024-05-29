namespace api.Entities.MQSocial
{
    public class Post
    {
        public int? Id { get; set; }
        public string? Content { get; set; } = "";
        public int? TotalReactions { get; set; } = 0;
        public bool? IsEdited { get; set; } = false;
        public int? UserId { get; set; }
        public User? User { get; set; }
        public int? GroupId { get; set; }
        public Group? Group { get; set; }
        public int? SharedPostId { get; set; } = 0;
        public List<PostReaction> Reactions { get; set; } = new();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    }
}
