using CinemaSite.Domain.Interfaces;
using CinemaSite.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CinemaSite.API.Controllers
{
    public class MovieController(IMoviesRepository moviesRepository) : MyBaseContriller
    {
        [HttpGet("get")]
        public async Task<List<MovieModel>> GetMovies()
        {
            var result = await moviesRepository.Get();

            Console.WriteLine("Test");
            
            return result;
        }

        [HttpGet("getbyid")]
        public async Task<MovieModel?> GetById(Guid guid)
        {
            var result = await moviesRepository.GetById(guid);

            return result;
        }


        [HttpGet("getbytitle")]
        public async Task<MovieModel?> GetByTitle(string title)
        {
            var result = await moviesRepository.GetByTitle(title);

            return result;
        }


        [HttpPost("add")]
        public IActionResult AddMovie(MovieModel movieModel)
        {
            moviesRepository.Add(movieModel);

            return Ok();
        }
    }
}
