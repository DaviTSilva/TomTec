using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tomtec.Lib.Models
{
    //This class is needed for the many-to-many relationship between Roles and Users
    public class UserRoles
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
