using AspNetAuth.Models;
using AspNetAuth.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService) {
            _authService = authService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(LoginUser user)
        {
            if (await _authService.RegisterUser(user))
            {
                return Ok("Registered successfully");
            }
            return BadRequest("Something went wrong");

        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUser user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _authService.Login(user);
            if (result == true)
            {
                var tokenString = _authService.generateTokenString(user);
                return Ok(tokenString);
            }
            return BadRequest();
        }
    }
}
