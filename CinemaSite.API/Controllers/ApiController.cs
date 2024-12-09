using CinemaSite.BusinessLogic.Intefaces.Services;
using CinemaSite.Domain.Interfaces;
using CinemaSite.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CinemaSite.API.Controllers
{
    public class ApiController(IUsersRepository userRepository) : MyBaseContriller
    {
        [HttpGet("users")]
        public async Task<List<UserModel>> GetUsers()
        {
            var users = await userRepository.Get();

            return users;
        }

        [HttpGet]
        public IActionResult GetUserById(Guid id)
        {
            return Ok(userRepository.GetById(id));
        }

        [HttpGet("userbylogin")]
        public UserModel? GetUserByLogin(string login)
        {
            return userRepository.GetByLogin(login);
        }

        [HttpGet]
        public IActionResult GetUserByEmail(string email)
        {
            return Ok(userRepository.GetByEmail(email));
        }
    }
}
