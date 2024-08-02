﻿using System.ComponentModel.DataAnnotations;

namespace api.DTOs.Users
{
    public class RegisterDto
    {
        [Required]
        public string? Username { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }

        public string? Bio { get; set; }
    }
}
