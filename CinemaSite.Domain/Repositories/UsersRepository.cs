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
    public class UsersRepository(CinemaDbContext dbContext) : IUserRepository
    {
        public async Task<List<UserModel>> Get()
        {
            return await dbContext.Users
                .AsNoTracking()
                .OrderBy(u => u.Login)
                .ToListAsync();
        }

        public async Task<UserModel?> GetById(Guid id)
        {
            return await dbContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public Task<UserModel?> GetByLogin(string login)
        {
            var query = dbContext.Users.AsNoTracking();

            if(login != null && login != "")
            {
                query = query.Where(u => u.Login.Contains(login));
            }

            return query.FirstOrDefaultAsync();
        }

        public async Task Add(UserModel user)
        {
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
        }
    }
}
