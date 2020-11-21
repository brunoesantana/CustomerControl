using System;
using System.ComponentModel.DataAnnotations;

namespace CustomerControl.CrossCutting.Dto.Customer
{
    public class CustomerInsertDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public char Gender { get; set; }

        public string Cep { get; set; }
        public string Adress { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string Neighborhood { get; set; }
        public string State { get; set; }
        public string City { get; set; }
    }
}