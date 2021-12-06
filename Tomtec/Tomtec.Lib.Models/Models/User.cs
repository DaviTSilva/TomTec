using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Tomtec.Lib.Models
{
    public class User
    {
        public int Id { get; set; }

        [Column(TypeName="varchar(100)")]
        [Required]
        public string UserName { get; set; }

        [Column(TypeName = "varchar(100)")]
        [Required] 
        public string FirstName { get; set; }

        [Column(TypeName = "varchar(120)")]
        public string LastName { get; set; }

        public Address Address { get; set; }

        public int AddressId { get; set; }

        [Column(TypeName = "varchar(150)")]
        [Required]
        public string Email { get; set; }

        public UserType UserType { get; set; }

        public int UserTypeId { get; set; }

        public ICollection<UserRoles> UserRoles { get; set; }

        [Required]
        public string Password { get; set; }

        [Column(TypeName = "varchar(200)")]
        [Required]
        public string PasswordSalt { get; set; }

    }
}
