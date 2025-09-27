

using EnterprisePatterns.DbContexts;
using EnterprisePatterns.DemoServices;
using EnterprisePatterns.Entities;
using EnterprisePatterns.Repositories;
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
            services.AddScoped<RepositoryDemoService>();
            services.AddScoped<UnitOfWorkDemoService>();
          // services.AddScoped<IRepository<Order>, GenericOrderRepository>();
            services.AddScoped<IRepository<Order>, GenericEFCoreRepository<Order>>();
            services.AddScoped<IOrderLineRepository, OrderLineRepository>();


            return services;
        }
    }
}
