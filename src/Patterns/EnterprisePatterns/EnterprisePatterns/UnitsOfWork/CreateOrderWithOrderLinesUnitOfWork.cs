using EnterprisePatterns.DbContexts;
using EnterprisePatterns.Entities;
using EnterprisePatterns.Repositories;

namespace EnterprisePatterns.UnitsOfWork
{
    public class CreateOrderWithOrderLinesUnitOfWork : UnitOfWork
    {
        public CreateOrderWithOrderLinesUnitOfWork(OrderDbContext orderDbContext, 
                IRepository<Order> orderRepository,
                 IOrderLineRepository orderLineRepository) 
            : base(orderDbContext)
        {
            OrderRepository = orderRepository;
            OrderLineRepository = orderLineRepository;
        }

        public IRepository<Order> OrderRepository { get; }
        public IOrderLineRepository OrderLineRepository { get; }
    }
}
