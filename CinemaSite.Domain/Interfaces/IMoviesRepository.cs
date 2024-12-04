using CinemaSite.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSite.Domain.Interfaces
{
    public interface IMoviesRepository
    {
        Task<List<MovieModel>> Get();
        Task<MovieModel> GetById(Guid id);
        Task<List<MovieModel>> GetByFilter(string title, decimal price);
        Task<MovieModel?> GetByTitle(string title);

        Task Add(MovieModel movie);

        Task Update(MovieModel movie);

        Task Delete(Guid id);

        Task Delete(MovieModel movie);
    }
}
