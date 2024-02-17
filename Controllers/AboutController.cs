using Microsoft.AspNetCore.Mvc;

namespace Mmr.RestApi.Demo.Controllers
{
    [ApiController]
    [Route("about")]
    public class AboutController : ControllerBase
    {

        [HttpGet("data")]
        public IActionResult GetActionResult()
        {
            var res = new AboutData{ Version = 1 };

            return Ok(res);
        }

        public class AboutData
        {
            public int Version { get; set; }
        }
    }
}
