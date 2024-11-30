using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSite.Domain.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string Login { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string HashPassword { get; set; } = string.Empty;

        public List<RoleModel> Roles { get; set; } = [];
        public List<MovieModel> Movies { get; set; } = [];
    }
}
