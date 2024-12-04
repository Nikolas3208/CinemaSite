using CinemaSite.BusinessLogic.Intefaces.Services;
using CinemaSite.Domain;
using CinemaSite.Domain.Enums;
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
    public class UserService(IUsersRepository repository, IPasswordHasher passwordHasher, JwtService jwtService) 
        : IUserService
    {
        public UserServiceType Register(string login, string email, string password)
        {
            var user = new UserModel
            {
                Login = login,
                Email = email,
                Id = Guid.NewGuid()
            };

            user.HashPassword = passwordHasher.Generate(user, password);

            var userget = repository.GetByLogin(login);

            if (userget == null)
            {
                if(repository.GetByEmail(email) == null)
                repository.Add(user);
            }
            else
                return UserServiceType.LoginBusy;

            return UserServiceType.Ok;
        }

        public string Login(string login, string password)
        {
            var user = repository.GetByLogin(login);
            if (user == null)
                return null;

            var result = passwordHasher.VerifyPassword(user, password);

            if (result)
            {
                return jwtService.GenerateToken(user);
            }
            else 
            {
                return null;
            }
        }
    }
}
