using CinemaSite.Domain.Interfaces;
using CinemaSite.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSite.Domain.Repositories
{
    public class MoviesRepository(CinemaDbContext dbContext) : IMoviesRepository
    {
        public async Task<List<MovieModel>> Get()
        {
            return await dbContext.Movies
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<MovieModel>> GetByFilter(string title, decimal price)
        {
            var query = dbContext.Movies.AsNoTracking();

            if (title != null && title != "")
            {
                query = query.Where(m => m.Title == title);
            }
            if(price > 0)
            {
                query = query.Where(m => m.Price >= price);
            }

            return await query.ToListAsync();
        }

        public Task<MovieModel> GetById(Guid id)
        {
            return dbContext.Movies.AsNoTracking().FirstAsync(m => m.Id == id);
        }

        public async Task<MovieModel?> GetByTitle(string title)
        {
            return await dbContext.Movies.AsNoTracking().FirstAsync(m => m.Title == title);
        }

        public async Task Add(MovieModel movie)
        {
            await dbContext.Movies.AddAsync(movie);
            await dbContext.SaveChangesAsync();
        }

        public Task Update(MovieModel movie)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Delete(MovieModel movie)
        {
            throw new NotImplementedException();
        }
    }
}
