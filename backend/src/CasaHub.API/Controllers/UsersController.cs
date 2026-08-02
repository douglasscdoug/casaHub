using CasaHub.Application.DTOs.Users;
using CasaHub.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CasaHub.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController(IUserService userService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateUserRequestDto request, CancellationToken cancellationToken)
        {
            var user = await userService.CreateAsync(
                request,
                cancellationToken);

            return CreatedAtAction(
                nameof(GetById),
                new { id = user.Id },
                user);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetById(Guid id)
        {
            return Ok();
        }
    }
}