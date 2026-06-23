

using EnterprisePatterns.DbContexts;
using EnterprisePatterns.DemoServices;
using EnterprisePatterns.Entities;
using EnterprisePatterns.Repositories;
using EnterprisePatterns.UnitsOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EnterprisePatterns
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddServiceRegistration(this IServiceCollection services,
                   IConfiguration configuration)
        {
            services.AddLogging(config => config.AddDebug().AddConsole());

            var dbPath = Path.Combine(AppContext.BaseDirectory, "Orders.db");

            services.AddDbContext<OrderDbContext>
                        (options => options
                        .UseSqlite($"Data Source={dbPath}"));
            

            // services.AddScoped<IRepository<Order>, GenericOrderRepository>();
            services.AddScoped<IRepository<Order>, GenericEFCoreRepository<Order>>();
            services.AddScoped<IOrderLineRepository, OrderLineRepository>();

            // Register generic repository
            services.AddScoped(typeof(IRepository<>), typeof(GenericEFCoreRepository<>));

            // Register Unit of Work
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Demo services
            services.AddScoped<RepositoryDemoService>();
            services.AddScoped<UnitOfWorkDemoService>();


            return services;
        }
    }
}
