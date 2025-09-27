using EnterprisePatterns.DbContexts;
using EnterprisePatterns.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnterprisePatterns.Repositories
{
    public class GenericOrderRepository(OrderDbContext dbContext) : IRepository<Order>
    {
        private readonly OrderDbContext _dbContext = dbContext;

        public void Add(Order entity)
        {
            _dbContext.Orders.Add(entity);
        }

        public void Delete(Order entity)
        {
            _dbContext.Orders.Remove(entity);
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await _dbContext.Orders.ToListAsync();
        }

        public async Task<Order?> GetById(int id)
        {
            return await _dbContext.Orders.FindAsync(id);
        }

        public async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Update(Order entity)
        {
            //no implementation here.
        }
    }
}
