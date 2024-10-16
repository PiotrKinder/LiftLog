﻿using System.ComponentModel.DataAnnotations;

namespace DTO.Contracts.Auth
{
    public class AuthRequest
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
