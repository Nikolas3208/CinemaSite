using CinemaSite.Domain.Stores;
using CinemaSite.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSite.Persistence
{
    public class UserRepository : IUserStore
    {
        public UserModel GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public UserModel GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Add(UserModel model)
        {
            throw new NotImplementedException();
        }
    }
}
