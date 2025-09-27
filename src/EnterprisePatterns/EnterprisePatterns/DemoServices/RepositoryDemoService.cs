using EnterprisePatterns.Entities;
using EnterprisePatterns.Repositories;

namespace EnterprisePatterns.DemoServices
{
    public class RepositoryDemoService(IRepository<Order> genericOrderRepo,
                IOrderLineRepository orderLineRepository)
    {
        private readonly IRepository<Order> _genericOrderRepo = genericOrderRepo;
        private readonly IOrderLineRepository _orderLineRepository = orderLineRepository;

        public async Task RunAsync()
        {
            //load order
            var order = await _genericOrderRepo.GetById(1);

            if (order != null)
            {
                //update order
                order.Description = "Updated description for new order 2";

                await _genericOrderRepo.SaveChanges();


                OrderLine orderLine = new("Skirt", 1) { OrderId = order.Id };
                _orderLineRepository.Add(orderLine);

                await _orderLineRepository.SaveChanges();


            }
        }
    }
}
