using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Tomtec.Lib.Models
{
    public class User : IEntity<User>
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

        public ICollection<UsersClaims> UsersClaims { get; set; }

        [Required]
        [JsonIgnore]
        public string Password { get; set; }

        [Column(TypeName = "varchar(100)")]
        [Required]
        [JsonIgnore]
        public string PasswordSalt { get; set; }

        [Required]
        public bool Active { get; set; } = true;

    }
}
