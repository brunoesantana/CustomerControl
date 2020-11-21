using CustomerControl.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerControl.Domain
{
    public class User : EntityBase
    {
        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        [StringLength(100)]
        public string UserName { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        [StringLength(100)]
        public string Password { get; set; }
    }
}