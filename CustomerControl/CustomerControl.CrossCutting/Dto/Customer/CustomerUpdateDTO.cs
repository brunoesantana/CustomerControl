using CustomerControl.CrossCutting.Dto.Base;
using System;

namespace CustomerControl.CrossCutting.Dto.Customer
{
    public class CustomerUpdateDTO : BaseUpdateDTO
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
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