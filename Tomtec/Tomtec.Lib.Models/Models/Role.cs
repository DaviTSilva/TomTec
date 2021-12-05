using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tomtec.Lib.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<UserRoles> UserRoles { get; set; }
    }
}
