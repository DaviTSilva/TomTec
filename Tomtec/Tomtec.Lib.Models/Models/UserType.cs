using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tomtec.Lib.Models
{
    public class UserType
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(150)")]
        [Required]
        public string Name { get; set; }
    }
}