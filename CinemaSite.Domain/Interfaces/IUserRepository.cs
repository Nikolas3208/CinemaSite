using CinemaSite.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSite.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserModel>> Get();

        Task<UserModel?> GetById(Guid id);

        Task<UserModel?> GetByLogin(string login);

        Task Add(UserModel user);
    }
}
