using CustomerControl.Business.Base;
using CustomerControl.Business.Interface;
using CustomerControl.CrossCutting.Exceptions;
using CustomerControl.CrossCutting.Filter;
using CustomerControl.Data.Interface;
using CustomerControl.Domain;
using System;

namespace CustomerControl.Business.Service
{
    public class UserService : BaseService<User, UserFilter>, IUserService
    {
        public UserService(IUserRepository repository) : base(repository)
        {
        }

        public override Guid Create(User dto)
        {
            var user = ((IUserRepository)Repository).FindByLogin(dto.UserName);

            if (user != null && !user.Active)
                throw new NotFoundException();

            return base.Create(dto);
        }

        public override User Update(User dto)
        {
            var user = ((IUserRepository)Repository).Find(dto.Id);
            dto.Password = user.Password;

            return base.Update(dto);
        }

        public User Login(string login, string password)
        {
            var user = ((IUserRepository)Repository).Login(login, password);
            return user ?? throw new NotFoundException();
        }
    }
}