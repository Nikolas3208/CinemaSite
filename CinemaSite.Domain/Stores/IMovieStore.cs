using CinemaSite.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSite.Domain.Stores
{
    public interface IMovieStore
    {
        MovieModel GetById(Guid id);
        MovieModel GetByTitle(string title);
        void Add(MovieModel movie);
    }
}
