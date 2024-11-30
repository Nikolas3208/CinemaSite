using CinemaSite.BusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace CinemaSite.API.Controllers
{
    public class AuthController(AccountService accountService) : ControllerBase
    {
        [HttpPost("register")]
        public IActionResult Register(string login, string email, string password)
        {
            accountService.Register(login, email, password);
            return NoContent();
        }
    }
}
