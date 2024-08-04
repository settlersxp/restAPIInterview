using api.Data;
using api.DTOs.Users;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(
        UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager,
        ITokenService tokenService
            ) : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager = userManager;
        private readonly ITokenService _tokenService = tokenService;
        private readonly SignInManager<AppUser> _signInManager = signInManager;

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

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto) {
            try
            {
                var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == loginDto.Email);
                if (user == null) {
                    return Unauthorized("Invalid email");
                }

                //"true" for lockout might be useful for bypasses when wrong user is entered
                var passwordCheck = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
                if (!passwordCheck.Succeeded) {
                    return Unauthorized("Invalid username");
                }

                return Ok(new NewUserDto {  
                    Username = user.UserName,
                    Email = user.Email,
                    Token = _tokenService.CreateToken(user)
                });
            } catch (Exception e) {
                return BadRequest(e.Message);
            }
        }
    }
}
