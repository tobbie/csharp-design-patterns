using EnterprisePatterns.Entities;

namespace EnterprisePatterns.Repositories
{

  public interface IOrderLineRepository : IRepository<OrderLine>
    {
        Task<IEnumerable<OrderLine>> GetAllByOrderId(int orderId);
    }
   
}
