using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akelny.BLL.Dto.UserDto
{
    public class UserRegistrationRequestDto
    {
        [Required]
        public string Username { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password{ get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public IFormFile? ProfileImg { get; set; }
        public bool IsEmailVerified { get; set; }
        public string UserType { get; set; } = string.Empty;
        public DateTime DOB { get; set; }
        public string? Address { get; set; } = string.Empty;
    }
}
