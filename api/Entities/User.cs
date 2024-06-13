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
        public ICollection<Image> Images { get; set; } 
        public ICollection<Friendship> Friendship1 { get; set; } 
        public ICollection<Friendship> Friendship2 { get; set; } 

        public ICollection<Post> Posts { get; set; } 
        public ICollection<PostReaction>? PostReactions { get; set; }
        public ICollection<Group> Groups { get; set; }
        public ICollection<UserGroup>? UserGroups { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
