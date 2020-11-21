using CustomerControl.Business.Interface.Base;
using CustomerControl.CrossCutting.Filter;
using CustomerControl.Domain;

namespace CustomerControl.Business.Interface
{
    public interface IUserService : IServiceBase<User, UserFilter>
    {
        User Login(string login, string password);
    }
}