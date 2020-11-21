using CustomerControl.CrossCutting.Filter;
using CustomerControl.Data.Base;
using CustomerControl.Data.Context;
using CustomerControl.Data.Interface;
using CustomerControl.Domain;
using System.Collections.Generic;
using System.Linq;

namespace CustomerControl.Data.Repository
{
    public class CustomerRepository : BaseRepository<Customer, CustomerFilter>, ICustomerRepository
    {
        public CustomerRepository(DataContext context) : base(context)
        {
        }

        public override List<Customer> GetAll(CustomerFilter filter)
        {
            var query = _context.Set<Customer>().Where(w => w.Active);

            if (!string.IsNullOrWhiteSpace(filter.Term))
                query = query.Where(w => w.Name.Contains(filter.Term));

            return query.OrderBy(a => a.Name).ToList();
        }
    }
}