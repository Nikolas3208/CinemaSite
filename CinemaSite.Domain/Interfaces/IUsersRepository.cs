using CinemaSite.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSite.Domain.Interfaces
{
    public interface IUsersRepository
    {
        Task<List<UserModel>> Get();

        Task<UserModel?> GetById(Guid id);

        UserModel? GetByLogin(string login);

        UserModel? GetByEmail(string email);

        Task Add(UserModel user);

        Task Update(UserModel user);

        void RemoveAsync(UserModel user);

        void RemoveAsync(Guid id);
    }
}
