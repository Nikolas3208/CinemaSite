using Microsoft.AspNetCore.Mvc;

namespace CinemaSite.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
