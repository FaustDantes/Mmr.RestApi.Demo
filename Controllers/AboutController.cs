using Microsoft.AspNetCore.Mvc;
using Mmr.RestApi.Demo.Requests;
using Mmr.RestApi.Demo.Services;

namespace Mmr.RestApi.Demo.Controllers
{
    [ApiController]
    [Route("about")]
    public class AboutController : ControllerBase
    {
        private readonly ILogger<AboutController> _logger;

        public AboutController(IFileStorage storage, ILogger<AboutController> logger)
        {
            Storage = storage;
            _logger = logger;
        }

        public IFileStorage Storage { get; }

        [HttpGet("data")]
        public IActionResult GetActionResult()                
        {
            Storage.PrintCode();
            _logger.LogWarning("ERRRRORO");
            _logger.LogInformation("jsurt info ");
            _logger.LogCritical("critical stuff ajj ");

            var res = new AboutData{ Version = 1 };

            return Ok(res);
        }


        [HttpGet("data/all")]
        public IActionResult GetAllDataResult([FromQuery] FilterRequest<DataArgs> param)
        {
            var res = new AboutData { Version = param.Skip, Datas = string.Join("-", param.Datas?.Default ?? ["X"]) };

            return Ok(res);
        }

        public class AboutData
        {
            public int Version { get; set; }
            public string? Datas { get; set; }
        }
    }
}
