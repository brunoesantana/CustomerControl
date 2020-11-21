using CustomerControl.Domain.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerControl.Domain
{
    public class Customer : EntityBase
    {
        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "DATETIME")]
        [StringLength(25)]
        public DateTime BirthDate { get; set; }

        [Required]
        [Column(TypeName = "CHAR(1)")]
        [StringLength(1)]
        public char Gender { get; set; }

        [Column(TypeName = "VARCHAR(15)")]
        [StringLength(15)]
        public string Cep { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [StringLength(100)]
        public string Adress { get; set; }

        [Column(TypeName = "VARCHAR(10)")]
        [StringLength(10)]
        public string Number { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [StringLength(50)]
        public string Complement { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [StringLength(50)]
        public string Neighborhood { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [StringLength(50)]
        public string State { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [StringLength(100)]
        public string City { get; set; }
    }
}