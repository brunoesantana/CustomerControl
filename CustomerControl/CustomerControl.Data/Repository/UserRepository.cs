using CustomerControl.CrossCutting.Filter;
using CustomerControl.Data.Base;
using CustomerControl.Data.Context;
using CustomerControl.Data.Interface;
using CustomerControl.Domain;
using System.Collections.Generic;
using System.Linq;

namespace CustomerControl.Data.Repository
{
    public class UserRepository : BaseRepository<User, UserFilter>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context)
        {
        }

        public User Login(string login, string password)
        {
            return _context.Set<User>().FirstOrDefault(w => w.UserName.Equals(login) && w.Password.Equals(password));
        }

        public User FindByLogin(string login)
        {
            return _context.Set<User>().FirstOrDefault(w => w.UserName.Equals(login));
        }

        public override List<User> GetAll(UserFilter filter)
        {
            var query = _context.Set<User>().Where(w => w.Active);

            if (!string.IsNullOrWhiteSpace(filter.Term))
                query = query.Where(w => w.UserName == filter.Term);

            return query.OrderBy(a => a.UserName).ToList();
        }
    }
}