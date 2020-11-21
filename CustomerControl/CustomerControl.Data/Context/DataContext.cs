using CustomerControl.Domain;
using Microsoft.EntityFrameworkCore;

namespace CustomerControl.Data.Context
{
    public class DataContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Customer> Customer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies();
                optionsBuilder.UseSqlServer("Server=code-bruno\\SQLEXPRESS;Database=customer;Trusted_Connection=True");
            }

            base.OnConfiguring(optionsBuilder);
        }
    }
}