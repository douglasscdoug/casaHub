using CasaHub.Application.DTOs.Auth;
using CasaHub.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CasaHub.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<ActionResult<LoginResponseDto>> Login(
            LoginRequestDto request, CancellationToken cancellationToken
        )
        {
            var response = await authService.LoginAsync(request, cancellationToken);

            return Ok(response);
        }

        [Authorize]
        [HttpGet("me")]
        public IActionResult Me()
        {
            return Ok(new
            {
                Id = User.FindFirst("sub")?.Value,
                Email = User.FindFirst("email")?.Value,
                Name = User.FindFirst("name")?.Value
            });
        }
    }
}