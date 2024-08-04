using System.ComponentModel.DataAnnotations;

namespace api.DTOs.Users
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
