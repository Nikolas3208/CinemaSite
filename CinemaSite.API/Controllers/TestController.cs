using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaSite.API.Controllers
{
    [Authorize(Policy = "AdminPolicy")]
    public class TestController : MyBaseContriller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Ok");
        }
    }

    [Authorize(Policy = "UserPolicy")]
    public class Test2Controller : MyBaseContriller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Ok");
        }
    }
}
