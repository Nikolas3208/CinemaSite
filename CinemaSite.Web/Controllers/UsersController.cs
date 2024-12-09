using CinemaSite.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using CinemaSite.Client;
using CinemaSite.Persistence.Models;

namespace CinemaSite.Web.Controllers
{
    public class UsersController(Client.Client client, IWebHostEnvironment hostEnvironment) : Controller
    {
        public async Task<IActionResult> Index()
        {
            if (Users.user != null)
            {
                var result = await client.Http.GetFromJsonAsync<UserModel>($"Api/userbylogin?login={Users.user.Login}");

                return View(result);
            }

            return NoContent();
        }

        public IActionResult Logout()
        {
            Users.user = null;
            return Redirect("../../Home/Index/");
        }

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
            var result = await client.Http.GetFromJsonAsync<User>($"Auth/login?login={login}&password={password}");
            if (result != null)
            {
                client.AddHeader("Authorization", $"Bearer {result.Token}");
                Users.user = result;

                return Redirect("../Home/Index");
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie(string movie_title, DateTime release_date, string country, string director, string genre, string movie_description, IFormFile movie_poster, string price, string movie_file)
        {
            if (movie_file != null && movie_poster != null)
            {
                string wwwroot = hostEnvironment.WebRootPath;
                string poster = wwwroot + "\\files\\posters\\" + movie_poster.FileName;

                using (FileStream file = new FileStream(poster, FileMode.Create))
                {
                    await movie_poster.CopyToAsync(file);
                }

                MovieModel movieModel = new MovieModel
                {
                    Title = movie_title,
                    Description = movie_description,
                    Price = decimal.Parse(price),
                    Id = Guid.NewGuid(),
                    PosterPath = movie_poster.FileName,
                    MoviePath = movie_file,
                    Date = release_date,
                    Country = country,
                    Director = director,
                    Genre = genre
                };

                await client.Http.PostAsJsonAsync<MovieModel>("Movie/add", movieModel);

                return RedirectToAction("Index");
            }

            return NoContent();
        }
    }
}
