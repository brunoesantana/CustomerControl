using CustomerControl.Business.Interface;
using CustomerControl.CrossCutting.Filter;
using CustomerControl.Domain;
using NSubstitute;
using NUnit.Framework;
using Services.Test;
using System;
using System.Linq;

namespace Tests
{
    public class Tests
    {
        private IUserService _mockService;

        private const int VALUE_TWO = 2;
        private const string USER_NAME = "usuarioteste1";

        private readonly Guid USER_GUID = Guid.Parse("14b41bf3-1408-4adb-9ff3-6fb8bb7dce02");

        [SetUp]
        public void Setup()
        {
            _mockService = Substitute.For<IUserService>();

            _mockService.GetAll(Arg.Any<UserFilter>()).Returns(TestHelper.GetUsers());
            _mockService.Find(Arg.Any<Guid>()).Returns(TestHelper.GetUser());
            _mockService.Create(Arg.Any<User>()).Returns(USER_GUID);
            _mockService.Update(Arg.Any<User>()).Returns(TestHelper.GetUpdateUser());
        }

        [Test]
        public void Deve_retornar_lista_de_usuarios_corretamente()
        {
            var response = _mockService.GetAll(new UserFilter(""));

            Assert.IsTrue(response.Any());
            Assert.AreEqual(response.Count(), VALUE_TWO);

            var user = response.FirstOrDefault();

            Assert.IsTrue(user.Active);
            Assert.IsNull(user.Password);
        }

        [Test]
        public void Deve_retornar_usuario_corretamente()
        {
            var user = _mockService.Find(new Guid());

            Assert.IsNotNull(user);
            Assert.IsTrue(user.Active);
            Assert.IsNull(user.Password);
            Assert.AreEqual(user.UserName, USER_NAME);
        }

        [Test]
        public void Deve_inserir_usuario_corretamente()
        {
            var userGuid = _mockService.Create(new User());

            Assert.IsNotNull(userGuid);
            Assert.AreEqual(userGuid, USER_GUID);
        }

        [Test]
        public void Deve_atualizar_usuario_corretamente()
        {
            var user = _mockService.Find(new Guid());
            var userUpdate = _mockService.Update(user);

            Assert.IsNotNull(user);
            Assert.IsNotNull(userUpdate);
            Assert.AreNotEqual(user.Version, userUpdate.Version);
            Assert.IsTrue(userUpdate.Version > user.Version);
            Assert.AreEqual(userUpdate.Version, VALUE_TWO);
        }
    }
}