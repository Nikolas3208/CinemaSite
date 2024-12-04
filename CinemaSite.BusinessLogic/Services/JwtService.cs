using CinemaSite.Domain.Interfaces;
using CinemaSite.Domain.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CinemaSite.BusinessLogic.Services
{
    public class JwtService(IOptions<AuthSettings> options, IPasswordHasher passwordHasher)
    {
        public string GenerateToken(UserModel user)
        {
            var claims = new List<Claim>
            {
                new Claim("login", user.Login),
                new Claim("email", user.Email),
                new Claim("id", user.Id.ToString()),
                new Claim("User", "true")
            };
            if (user.Login == "admin" && passwordHasher.VerifyPassword(user, "admin"))
            {
                claims.Add(new Claim("Admin", "true"));
            }

            var jwtToken = new JwtSecurityToken(
                expires: DateTime.UtcNow.Add(options.Value.Expires),
                claims: claims,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Value.SecretKey)), SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }
    }
}
