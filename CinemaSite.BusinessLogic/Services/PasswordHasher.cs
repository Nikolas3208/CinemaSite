using CinemaSite.Domain.Interfaces;
using CinemaSite.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSite.BusinessLogic.Services
{
    public class PasswordHasher : IPasswordHasher
    {
        public string Generate(UserModel user, string password)
        {
            return new PasswordHasher<UserModel>().HashPassword(user, password);
        }

        public bool VerifyPassword(UserModel user, string password)
        {
            return new PasswordHasher<UserModel>().VerifyHashedPassword(user, user.HashPassword, password) == PasswordVerificationResult.Success ? true : false;
        }
    }
}
