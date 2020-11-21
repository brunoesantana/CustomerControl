using CustomerControl.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Test
{
    public static class TestHelper
    {
        public static List<User> GetUsers()
        {
            return new List<User>
            {
                new User
                {
                    Id = GetId(),
                    UserName = "usuarioteste1",
                    Date = DateTime.Now,
                    Active = true,
                    Version = 1
                },
                new User
                {
                    Id = GetId(),
                    UserName = "usuarioteste2",
                    Date = DateTime.Now,
                    Active = true,
                    Version = 1
                }
            };
        }

        public static User GetUser()
        {
            return GetUsers().FirstOrDefault();
        }

        public static User GetUpdateUser()
        {
            var user = GetUsers().LastOrDefault();
            user.Version = 2;

            return user;
        }

        public static List<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer
                {
                    Id = GetId(),
                    Name = "customer teste 1",
                    Adress = "rua teste 1",
                    BirthDate = new DateTime(1988,11,9),
                    Cep = "19000000",
                    City = "cidade teste 1",
                    Complement = "complemento teste 1",
                    Gender = 'M',
                    Neighborhood = "bairro teste 1",
                    Number = "1",
                    State = "estado teste 1",
                    Date = DateTime.Now,
                    Active = true,
                    Version = 1
                },
                new Customer
                {
                    Id = GetId(),
                    Name = "customer teste 2",
                    BirthDate = DateTime.Now,
                    Gender = 'F',
                    Date = DateTime.Now,
                    Active = true,
                    Version = 1
                },
                new Customer
                {
                    Id = GetId(),
                    Name = "customer teste 3",
                    BirthDate = DateTime.Now,
                    Gender = 'F',
                    Date = DateTime.Now,
                    Active = true,
                    Version = 1
                }
            };
        }

        public static Customer GetCustomer()
        {
            return GetCustomers().FirstOrDefault();
        }

        public static Customer GetUpdateCustomer()
        {
            var customer = GetCustomers().LastOrDefault();
            customer.Version = 2;

            return customer;
        }

        private static Guid GetId()
        {
            return Guid.NewGuid();
        }
    }
}