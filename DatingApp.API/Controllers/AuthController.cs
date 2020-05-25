using System.Threading.Tasks;
using DatingApp.API.Dtos;
using DatingApp.API.Models;
using DatingApp.API.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();

            if(await _authService.UserExists(userForRegisterDto.Username))
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
    }
}