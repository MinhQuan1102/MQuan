namespace api.DTOModels
{
    public class UserDTO
    {
        public string? Username { get; set; }
        public string? Token { get; set; }
        public string? Avatar { get; set; }
        public string? Gender { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public string? FullName { get; set; }
    }
}
