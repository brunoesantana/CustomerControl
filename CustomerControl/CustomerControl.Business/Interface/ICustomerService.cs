using CustomerControl.Business.Interface.Base;
using CustomerControl.CrossCutting.Filter;
using CustomerControl.Domain;

namespace CustomerControl.Business.Interface
{
    public interface ICustomerService : IServiceBase<Customer, CustomerFilter>
    {
    }
}