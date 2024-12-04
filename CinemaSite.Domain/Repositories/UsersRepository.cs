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
    public class UsersRepository(CinemaDbContext dbContext) : IUsersRepository
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

        public UserModel? GetByLogin(string login)
        {
            var user = dbContext.Users.AsNoTracking().FirstOrDefault(u => u.Login == login);

            return user;
        }

        public async Task Add(UserModel user)
        {
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
        }

        public UserModel? GetByEmail(string email)
        {
            var user = dbContext.Users.AsNoTracking().FirstOrDefault(u => u.Email == email);

            return user;
        }

        public async Task Update(UserModel user)
        {
            dbContext.Users.Update(user);
            await dbContext.SaveChangesAsync();
        }

        public async void RemoveAsync(UserModel user)
        {
            dbContext.Users.Remove(user);
            await dbContext.SaveChangesAsync();

        }

        public async void RemoveAsync(Guid id)
        {
            var user = GetById(id);

            dbContext.Users.Remove(user.Result);
            await dbContext.SaveChangesAsync();

        }
    }
}
