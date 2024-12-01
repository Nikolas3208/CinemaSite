using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSite.BusinessLogic.Intefaces.Services
{
    public interface IUserService
    {
        void Register(string login, string email, string password);

        string Login(string login, string password);
    }
}
