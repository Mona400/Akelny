﻿using Akelny.BLL.Dto.UserDto;
using Akelny.BLL.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Akelny.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
       // [Authorize]
        public  ActionResult<ReturnedUserDTO?>  GetUser(string id)
        {
            ReturnedUserDTO? UserDto =  _userService.GetUserDTO(id);

            if(UserDto == null) { return NotFound("No Such User"); }

            return Ok(UserDto);
        }
    }
}
