using CinemaSite.BusinessLogic.Intefaces.Services;
using CinemaSite.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CinemaSite.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController(IUserService userService) : ControllerBase
    {
        [HttpPost("register")]
        public IActionResult Register(string login, string email, string password)
        {
            userService.Register(login, email, password);
            return Ok();
        }

        [HttpPost("login")]
        public IActionResult Login(string login, string password)
        {
            var result = userService.Login(login, password);
            return Ok(result);
        }
    }
}
