using System.ComponentModel.DataAnnotations;

namespace api.DTOModels
{
    public class RegisterDTO
    {
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public int Gender { get; set; }
        [Required]
        public DateOnly? DateOfBirth { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Username { get; set; }
    }
}
