using LW4_MIA_2.DTO;
using LW4_MIA_2.Repositories;
using Microsoft.AspNetCore.Mvc;
using LW4_MIA_2.Services;

namespace LW4_MIA_2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _auth;

        public AuthController(IAuthService auth)
        {
            _auth = auth;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var result = await _auth.RegisterAsync(request);
            if (result == null)
                return BadRequest("User already exists");

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var result = await _auth.LoginAsync(request);
            if (result == null)
                return Unauthorized("Invalid credentials");

            return Ok(new { accessToken = result });
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh(TokenRefreshRequest request)
        {
            var result = await _auth.RefreshTokenAsync(request);
            return Ok(result);
        }
    }
}
