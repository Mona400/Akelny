using Akelny.BLL.Dto.ReviewDto;
using Akelny.BLL.Dto.SubDto;
using Akelny.DAL.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akelny.BLL.Dto.UserDto;

public class ReturnedUserDTO
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public bool IsEmailVerified { get; set; }
    public string UserType { get; set; } = string.Empty;
    public DateTime DOB { get; set; }
    public string? Address { get; set; } = string.Empty;

    public Gender Gender { get; set; }

   // public AuthResult? AuthResult { get; set; }

    public string? ProfileImg { get; set; } = string.Empty;
    public List<MinSubDTO>? Subscriptions { get; set; }

    public List<MinReviewDTO>? Reviews { get; set; }
}


public class UpdatedUserDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public string? Address { get; set; } = string.Empty;

    public IFormFile? ProfileImg { get; set; }
}