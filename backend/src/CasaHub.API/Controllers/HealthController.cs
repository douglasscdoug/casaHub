using Microsoft.AspNetCore.Mvc;

namespace CasaHub.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                status = "API funcionando",
                timestamp = DateTime.UtcNow
            });
        }
    }
}