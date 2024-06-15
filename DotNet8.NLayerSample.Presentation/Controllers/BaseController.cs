using DotNet8.NLayerSample.Presentation.Resources;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DotNet8.NLayerSample.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IActionResult Content(object? obj)
        {
            return StatusCode(200, JsonConvert.SerializeObject(obj));
        }

        protected IActionResult Created()
        {
            return StatusCode(201, MessageResource.SaveSuccess);
        }

        protected IActionResult Updated()
        {
            return StatusCode(202, MessageResource.SaveSuccess);
        }

        protected IActionResult Deleted()
        {
            return StatusCode(202, MessageResource.DeleteSuccess);
        }
    }
}
