using api.DTOModels;
using api.Entities.MQSocial;
using Microsoft.AspNetCore.Identity;

namespace api.Entities
{
    public class User : IdentityUser<int>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public DateTime LastActive { get; set; } = DateTime.UtcNow;
        public string? Gender { get; set; }
        public string? Avatar { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? District { get; set; }
        public List<Image> Images { get; set; } = new();
        public List<Post> Posts { get; set; } = new();
        public List<PostReaction> PostReactions { get; set; } = new();
        public ICollection<UserRole> UserRoles { get; set; }

   
        //public ICollection<UserGroup> UserGroups { get; set; }

    }
}
