using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tomtec.Lib.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public int AddressId { get; set; }
        public string Email { get; set; }
        public UserType UserType { get; set; }
        public int UserTypeId { get; set; }
        public ICollection<UserRoles> UserRoles { get; set; }
        public string Password { get; set; }
    }
}
