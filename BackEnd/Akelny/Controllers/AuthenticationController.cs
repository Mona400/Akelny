using Akelny.BLL.Dto.UserDto;
using Akelny.DAL.Context;
using Akelny.DAL.Models;
using Akelny.DAL.UnitOfWork;
using Akelny.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Akelny.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        // private readonly JWT _jWT;
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _context;
        private readonly TokenValidationParameters _tokenValidationParameters;
        public AuthenticationController( IUnitOfWork unitOfWork , UserManager<User> userManager, IConfiguration configuration, ApplicationDbContext context, TokenValidationParameters tokenValidationParameters, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _unitOfWork= unitOfWork;
            _configuration = configuration;
            _context = context;
            _tokenValidationParameters = tokenValidationParameters;
            _roleManager = roleManager;
            // _jWT = jWT;

        }
        [HttpPost]
        [Route("Register")]
        
        public async Task<IActionResult> Register([FromForm] UserRegistrationRequestDto userRegistrationRequestDto)
        {
            //valid the Incomming Request
            if (ModelState.IsValid)
            {
                var _exist = await _userManager.FindByEmailAsync(userRegistrationRequestDto.Email);
                if (_exist != null)
                {
                    return BadRequest(new AuthResult()
                    {

                        Errors = new List<string>()
                        {
                            "Email Already Exist"
                        },
                        Result = false
                    });
                }

                var imageName = _unitOfWork.SaveImageMethod(userRegistrationRequestDto.ProfileImg);
                //create User
                var _user = new User
                {
                    Email = userRegistrationRequestDto.Email,
                    UserName = userRegistrationRequestDto.Username,
                    Address=userRegistrationRequestDto.Address,
                    FirstName=userRegistrationRequestDto.FirstName,
                    LastName=userRegistrationRequestDto.LastName,
                    DOB=userRegistrationRequestDto.DOB,
                    ProfileImg=imageName,

                    
                };
                if(!await _roleManager.RoleExistsAsync(userRegistrationRequestDto.UserType))
                {
                    await _roleManager.CreateAsync(new IdentityRole(userRegistrationRequestDto.UserType));
                }
             
                var is_Created = await _userManager.CreateAsync(_user, userRegistrationRequestDto.Password);
           
                if (is_Created.Succeeded)
                {
                    //Generate Token
                    var tokent = await GenerateJwtToken(_user);
                    return Ok(tokent);
                }
                await _userManager.AddToRoleAsync(_user, userRegistrationRequestDto.UserType);
                return BadRequest(new AuthResult()
                {


                    Errors = new List<string>()
                    {
                        "Server Error"
                    },
                    Result = false
                });
            }
            return BadRequest();
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequestDto userLoginRequestDto)
        {
            if (ModelState.IsValid)
            {
                var _user = await _userManager.FindByEmailAsync(userLoginRequestDto.Email);
                if (_user == null)
                {
                    return BadRequest(new AuthResult()
                    {
                        Errors = new List<string>()
                        {
                            "Invalid Payload"
                        },
                        Result = false
                    });

                }
                var isCorrect = await _userManager.CheckPasswordAsync(_user, userLoginRequestDto.Password);
                if (!isCorrect)
                {
                    return BadRequest(new AuthResult()
                    {
                        Errors=new List<string>()
                        {
                            "Invalid Credentials"
                        },
                        Result = false
                    });
               
                };
                var jwtToken = await GenerateJwtToken(_user);
                return Ok(jwtToken);
            }
            return BadRequest(new AuthResult()
            {
                Errors = new List<string>()
                        {
                            "Invalid Payload"
                        },
                Result = false
            });

        }

        private async Task<AuthResult> GenerateJwtToken(User user)
        {
            var JwtTokenHandler = new JwtSecurityTokenHandler();
            var Key = Encoding.UTF8.GetBytes(_configuration.GetSection(key: "JWTConfig:Secret").Value!);

            //Token Descriptor
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", user.Id),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email!),
                    new Claim(JwtRegisteredClaimNames.Email, value: user.Email!),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),

                }),
                //Expire Refress Token
                Expires = DateTime.UtcNow.Add(TimeSpan.Parse(_configuration.GetSection(key: "JWTConfig:ExpireTimeFrame").Value!)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Key), SecurityAlgorithms.HmacSha256)
            };

            var token = JwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = JwtTokenHandler.WriteToken(token);

            var refreshToken = new RefreshToken()
            {
                JwtId=token.Id,
                Token=RandomStringGenerator(23),
                AddedDate=DateTime.UtcNow,
                ExpiryDate=DateTime.UtcNow.AddMonths(6),
                IsRevoked=false,
                IsUsed=false,
                UserId=user.Id
            };
            await _context.RefreshTokens.AddAsync(refreshToken);
            await _context.SaveChangesAsync();

            return new AuthResult()
            {
                Token=jwtToken,
                RefreshToken=refreshToken.Token,
                Email = user.Email,
                UserID = user.Id,
                Username = user.UserName,
                ProfileImg = user.ProfileImg,
                Result=true
            };

        }
        private string RandomStringGenerator(int length)
        {
            var random = new Random();
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890abcdefghijklmnopqrstuvwxyz_";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());

        }



    }
}
