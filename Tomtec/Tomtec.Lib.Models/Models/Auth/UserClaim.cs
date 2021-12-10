using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tomtec.Lib.Models
{
    public class UserClaim : IEntity<UserClaim>
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(200)")]
        [Required]
        public string Name { get; set; }

        public ICollection<UsersClaims> UsersClaims { get; set; }
    }
}
