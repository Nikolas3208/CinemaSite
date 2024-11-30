using CinemaSite.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSite.Domain.Stores
{
    public interface IUserStore
    {
        UserModel GetById(Guid id);
        UserModel GetByName(string name);
        void Add(UserModel model);
    }
}
