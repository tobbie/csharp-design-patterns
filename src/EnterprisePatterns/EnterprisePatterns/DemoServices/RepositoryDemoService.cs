using EnterprisePatterns.Entities;
using EnterprisePatterns.Repositories;

namespace EnterprisePatterns.DemoServices
{
    public class RepositoryDemoService(IRepository<Order> genericOrderRepo)
    {
        private readonly IRepository<Order> _genericOrderRepo = genericOrderRepo;

        public async Task RunAsync()
        {
            //load order
            var order = await _genericOrderRepo.GetById(1);

            if (order != null)
            {
                //update order
                order.Description = "Updated description by tobi ok";
                await _genericOrderRepo.SaveChanges();
            }
        }
    }
}
