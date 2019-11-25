using Microsoft.AspNetCore.Mvc;

namespace AmazingServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudyController : ControllerBase
    {
        // GET study/ping
        [HttpGet("ping")]
        public ActionResult Ping()
        {
            return Ok();
        }
    }
}