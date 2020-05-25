using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DatingApp.API.Dtos;
using DatingApp.API.Models;
using DatingApp.API.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IConfiguration _config;
        public AuthController(IAuthService authService, IConfiguration config)
        {
            _config = config;
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();

            if (await _authService.UserExists(userForRegisterDto.Username))
            {
                return BadRequest("Username already exists!");
            }

            var UserToCreate = new User
            {
                UserName = userForRegisterDto.Username

            };

            var createdUser = await _authService.Register(UserToCreate, userForRegisterDto.Password);

            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            userForLoginDto.Username = userForLoginDto.Username.ToLower();

            var user = await _authService.Login(userForLoginDto.Username, userForLoginDto.Password);

            if (user == null)
            {
                return Unauthorized();
            }
            else
            {
                var token = _authService.CreateToken(user.Id.ToString(), user.UserName);

                var tokenHandler = new JwtSecurityTokenHandler();

                return Ok(new {
                    token = tokenHandler.WriteToken(token)
                });
            }
        }
    }
}