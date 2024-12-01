using CinemaSite.BusinessLogic.Intefaces.Services;
using CinemaSite.Domain;
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
    public class UserService(IUserRepository repository, JwtService jwtService) : IUserService
    {
        public void Register(string login, string email, string password)
        {
            var user = new UserModel
            {
                Login = login,
                Email = email,
                Id = Guid.NewGuid()
            };

            user.HashPassword = new PasswordHasher<UserModel>().HashPassword(user, password);

            repository.Add(user);
        }

        public string Login(string login, string password)
        {
            var user = repository.GetByLogin(login).Result;
            if (user == null)
                return null;

            var result = new PasswordHasher<UserModel>().VerifyHashedPassword(user, user.HashPassword, password);

            if (result == PasswordVerificationResult.Success)
            {
                return jwtService.GenerateToken(user);
            }
            else 
            {
                throw new Exception();
            }

            return null;
        }
    }
}
