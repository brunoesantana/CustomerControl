using CustomerControl.CrossCutting.Filter;
using CustomerControl.Data.Interface.Base;
using CustomerControl.Domain;

namespace CustomerControl.Data.Interface
{
    public interface ICustomerRepository : IRepositoryBase<Customer, CustomerFilter>
    {
    }
}