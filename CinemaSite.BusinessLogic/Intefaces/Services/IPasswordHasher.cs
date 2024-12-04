using CinemaSite.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSite.Domain.Interfaces
{
    public interface IPasswordHasher
    {
        string Generate(UserModel user, string password);

        bool VerifyPassword(UserModel user, string password);
    }
}
