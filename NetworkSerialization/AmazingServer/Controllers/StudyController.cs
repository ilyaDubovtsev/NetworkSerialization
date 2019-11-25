using Common;
using Microsoft.AspNetCore.Mvc;

namespace AmazingServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudyController : ControllerBase
    {
        // GET Study/Ping
        [HttpGet("ping")]
        public ActionResult Ping()
        {
            return Ok();
        }

        // GET Study/PostInputData
        [HttpGet("PostInputData")]
        public JsonResult PostInputData()
        {
            var input = new Input
            {
                K = 10,
                Sums = new[] {1.01m, 2.02m},
                Muls = new[] {1, 4}
            };

            return new JsonResult(input);
        }
    }
}