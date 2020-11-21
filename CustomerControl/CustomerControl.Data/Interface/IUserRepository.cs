using CustomerControl.CrossCutting.Filter;
using CustomerControl.Data.Interface.Base;
using CustomerControl.Domain;

namespace CustomerControl.Data.Interface
{
    public interface IUserRepository : IRepositoryBase<User, UserFilter>
    {
        User Login(string login, string password);

        User FindByLogin(string login);
    }
}