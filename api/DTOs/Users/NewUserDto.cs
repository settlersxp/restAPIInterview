using System.ComponentModel.DataAnnotations;

namespace api.DTOs.Users
{
    public class NewUserDto
    {
        public required string Username { get; set; }

        [EmailAddress]
        public required string Email { get; set; }
        public required string Token { get; set; }
    }
}
