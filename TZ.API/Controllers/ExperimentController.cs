using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TZ.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperimentController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {

            return Ok("Ok object");
        }
    }
}
