using CinemaSite.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CinemaSite.Web.Controllers
{
    public class HomeController(Client.Client client) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var result = await client.Http.GetFromJsonAsync<List<MovieModel>>("Movie/get");
            if(result != null)
                return View(result);

            return NoContent();
        }

        public async Task<IActionResult> MovieView(string title)
        {
            var result = await client.Http.GetFromJsonAsync<MovieModel>($"Movie/getbytitle?title={title}");

            return View(result);
        }
    }
}
