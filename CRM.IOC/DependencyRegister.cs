using CRM.BL.Customers;
using CRM.DAL;
using CRM.DAL.DesignPattern;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;



namespace CRM.IOC
{
    public static class DependencyRegister
    {


        public static void RegisterDBContext( this IServiceCollection  services,string connectionString)
        {
            services.AddSqlServer<CRMDBContext>(connectionString);

        }

        public static void Register( this IServiceCollection  services)
        {
            services.AddScoped(typeof(IRepository<>),typeof(Repository<>));

            services.AddScoped<CustomerBL>();
        }
    }
}
