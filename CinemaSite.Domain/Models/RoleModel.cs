using CinemaSite.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSite.Domain.Models
{
    public class RoleModel
    {
        public Guid Id { get; set; }
        public Role Role { get; set; }

        public List<UserModel> Users { get; set; } = [];
    }
}
