using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mmr.Universal;

namespace Mmr.ModuleUnivers.Controllers.Universe.v1
{
    [ApiController]
    [Route("v1/universe")]
    public class UniverseController : ControllerBase
    {
        [HttpGet("age") ]
        public IActionResult GetUniverseAge()
        {
            var res = $"Age is {UniversalService.CalculateAge()} years";
            return Ok(res);
        }
    }    
}
// issues 
// 1 https://stackoverflow.com/questions/10311347/duplicate-assemblyversion-attribute
// 2 https://stackoverflow.com/questions/61997928/errorcs0579duplicate-globalsystem-runtime-versioning-targetframeworkattribu
// 3 https://stackoverflow.com/questions/76996557/microsoft-aspnetcore-mvc-core-marked-as-deprecated-and-causing-publishing-errors
// 4 swagger https://docs.telerik.com/reporting/knowledge-base/conflicting-actions-error-in-swagger-generation-net-core
// 5 