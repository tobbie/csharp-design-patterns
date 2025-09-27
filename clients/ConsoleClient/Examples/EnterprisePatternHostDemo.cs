using EnterprisePatterns;
using EnterprisePatterns.DemoServices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ConsoleClient.Examples
{
    public static class EnterprisePatternHostDemo
    {
        public static async Task RunAsync(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    services.AddServiceRegistration(context.Configuration);
                })
                .Build();

            using var scope = host.Services.CreateScope();
            // var demoService = scope.ServiceProvider.GetRequiredService<RepositoryDemoService>();
            var unitOfWorkService = scope.ServiceProvider.GetRequiredService<UnitOfWorkDemoService>();
            await unitOfWorkService.RunAsync();
            //await demoService.RunAsync();
        }
    }
}
