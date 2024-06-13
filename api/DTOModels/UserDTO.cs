using api.DTOModels.MQSocial;
using api.Entities.MQSocial;

namespace api.DTOModels
{
    public class UserDTO
    {
        public int? Id { get; set; }
        public string? Username { get; set; }
        public string? Avatar { get; set; }
        public string? Gender { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public string? FullName { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? District { get; set; }
        public List<ImageDTO>? Images { get; set; }
        public List<FriendDTO>? Friends { get; set; }
        public List<PostDTO>? Posts { get; set; }
    }
}
