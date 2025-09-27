using EnterprisePatterns.Entities;

namespace EnterprisePatterns.Repositories
{

  public interface IOrderLineRepository : IRepository<OrderLine>
    {
        Task<IEnumerable<OrderLine>> GetAllByOrderId(int orderId);
    }
    //public interface IOrderLineRepository
    //{
    //    Task<OrderLine?> GetById(int id);
    //    Task<IEnumerable<OrderLine>> GetAll(int id);
    //    Task<IEnumerable<OrderLine>> GetAllByOrderId(int orderId);
    //    void Add(OrderLine entity);
    //    void Delete(OrderLine entity);
    //    void Update(OrderLine entity);
    //    Task SaveChanges();
    //}
}
