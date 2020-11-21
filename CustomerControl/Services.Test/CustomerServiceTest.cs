using CustomerControl.Business.Interface;
using CustomerControl.CrossCutting.Filter;
using CustomerControl.Domain;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Linq;

namespace Services.Test
{
    public class CustomerServiceTest
    {
        private ICustomerService _mockService;

        private const int VALUE_THREE = 3;
        private const int VALUE_TWO = 2;
        private const string CUSTOMER_NAME = "customer teste 1";
        private const char GENDER_M = 'M';

        private readonly Guid CUSTOMER_GUID = Guid.Parse("4e52cc40-2167-4f17-961c-00616e185732");
        private readonly DateTime CUSTOMER_BIRTHDATE = new DateTime(1988, 11, 9);

        [SetUp]
        public void Setup()
        {
            _mockService = Substitute.For<ICustomerService>();

            _mockService.GetAll(Arg.Any<CustomerFilter>()).Returns(TestHelper.GetCustomers());
            _mockService.Find(Arg.Any<Guid>()).Returns(TestHelper.GetCustomer());
            _mockService.Create(Arg.Any<Customer>()).Returns(CUSTOMER_GUID);
            _mockService.Update(Arg.Any<Customer>()).Returns(TestHelper.GetUpdateCustomer());
        }

        [Test]
        public void Deve_retornar_lista_de_customers_corretamente()
        {
            var response = _mockService.GetAll(new CustomerFilter(""));

            Assert.IsTrue(response.Any());
            Assert.AreEqual(response.Count(), VALUE_THREE);
        }

        [Test]
        public void Deve_retornar_customer_corretamente()
        {
            var customer = _mockService.Find(new Guid());

            Assert.IsNotNull(customer);
            Assert.IsTrue(customer.Active);
            Assert.AreEqual(customer.Name, CUSTOMER_NAME);
            Assert.AreEqual(customer.Gender, GENDER_M);
            Assert.AreEqual(customer.BirthDate, CUSTOMER_BIRTHDATE);
        }

        [Test]
        public void Deve_inserir_customer_corretamente()
        {
            var customerGuid = _mockService.Create(new Customer());

            Assert.IsNotNull(customerGuid);
            Assert.AreEqual(customerGuid, CUSTOMER_GUID);
        }

        [Test]
        public void Deve_atualizar_customer_corretamente()
        {
            var customer = _mockService.Find(new Guid());
            var customerUpdate = _mockService.Update(customer);

            Assert.IsNotNull(customer);
            Assert.IsNotNull(customerUpdate);
            Assert.AreNotEqual(customer.Version, customerUpdate.Version);
            Assert.IsTrue(customerUpdate.Version > customer.Version);
            Assert.AreEqual(customerUpdate.Version, VALUE_TWO);
        }
    }
}