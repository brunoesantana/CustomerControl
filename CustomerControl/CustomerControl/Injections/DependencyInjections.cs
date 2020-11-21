using CustomerControl.Business.Interface;
using CustomerControl.Business.Service;
using CustomerControl.Data.Context;
using CustomerControl.Data.Interface;
using CustomerControl.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerControl.Injections
{
    public static class DependencyInjections
    {
        public static void AddDependencyInjections(this IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddSingleton<DataContext>();
        }
    }
}