namespace api.Entities.MQSocial
{
    public class Group
    {
        public int Id { get; set; }
        public int? GroupType { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? CoverImage { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<UserGroup>? UserGroups { get; set; }

    }
}
