using CinemaSite.Domain.Interfaces;
using CinemaSite.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CinemaSite.API.Controllers
{
    public class MovieController(IMoviesRepository moviesRepository) : MyBaseContriller
    {
        [HttpGet("get")]
        public IActionResult GetMovies()
        {
            return Ok(moviesRepository.Get());
        }

        [HttpPost("add")]
        public IActionResult AddMovie(string title, IFormFile? formFile)
        {
            var movie = new MovieModel
            {
                Title = title,
                Id = Guid.NewGuid()
            };

            moviesRepository.Add(movie);

            return Ok(movie);
        }
    }
}
