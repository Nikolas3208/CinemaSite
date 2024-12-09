using CinemaSite.BusinessLogic.Intefaces.Services;
using CinemaSite.Domain;
using CinemaSite.Domain.Models;
using CinemaSite.Persistence.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaSite.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MyBaseContriller : ControllerBase { }

    public class AuthController(IUserService userService) : MyBaseContriller
    {
        [HttpPost("register")]
        public IActionResult Register(string login, string email, string password)
        {
            var result = userService.Register(login, email, password);
            if (result == Domain.Enums.UserServiceType.Ok)
                return Ok();
            else
                throw new Exception();
        }

        [HttpPost("register2")]
        public IActionResult Register(User user)
        {
            return Register(user.Login, user.Email, user.Password);
        }

        [HttpGet("login")]
        public User Login(string login, string password)
        {
            var result = userService.Login(login, password);
            return result;
        }

        [HttpGet("login2")]
        public User Login(User user)
        {
            return Login(user.Login, user.Password);
        }
    }
}
