using CinemaSite.Domain.Models;
using CinemaSite.Persistence.Model;
using Microsoft.AspNetCore.Mvc;
using CinemaSite.Client;

namespace CinemaSite.Web.Controllers
{
    public class UsersController(Client.Client client) : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterPost(string login, string email, string password)
        {
            var user = await client.Http.PostAsJsonAsync<User>($"Auth/register2", new User { Login = login, Email = email, Password = password});

            return Redirect("../Home/Index");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginPost(string login, string password)
        {            
            var result = await client.Http.GetStringAsync($"Auth/login?login={login}&password={password}");
            if (result != null && result != "")
            {
                client.HttpClientSettings.AddHeader("Authorization", $"Bearer {result}");

                return Redirect("../Home/Index");
            }

            return NoContent();
        }
    }
}
