using api.Data;
using api.DTOs.Users;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;

        public UsersController(
            UserManager<AppUser> userManager, 
            ITokenService tokenService
            )
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto) {
            try
            {
                if (!ModelState.IsValid) {
                    return BadRequest("Invalid user model");
                }

                var newUser = new AppUser
                {
                    UserName = registerDto.Username,
                    Email = registerDto.Email,
                    Bio = registerDto.Bio
                };

                var createUser = await _userManager.CreateAsync(newUser, registerDto.Password);
                if (!createUser.Succeeded) {
                    return BadRequest(createUser.Errors);
                }

                var role = await _userManager.AddToRoleAsync(newUser, "User");
                if (!role.Succeeded) {
                    return BadRequest(role.Errors);
                }

                return Ok(new NewUserDto {  
                    Username = newUser.UserName,
                    Email = newUser.Email,
                    Token = _tokenService.CreateToken(newUser)
                });
            } catch (Exception e) {
                return BadRequest(e.Message);
            }
        }
    }
}
