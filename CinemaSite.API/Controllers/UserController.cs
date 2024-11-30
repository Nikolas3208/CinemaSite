using Microsoft.AspNetCore.Mvc;

namespace CinemaSite.API.Controllers
{
    public class UserController
    {
        [HttpGet]
        public string Index()
        {
            return "Hello";
        }
    }
}
