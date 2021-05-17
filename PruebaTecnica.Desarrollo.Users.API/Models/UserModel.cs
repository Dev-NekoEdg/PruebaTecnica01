using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnica.Desarrollo.Users.API.Models
{
    public class UserModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public DateTime? CreateAt { get; set; }

        public string RoleId { get; set; }

        public string RoleName { get; set; }

        public bool Active { get; set; }
    }
}
