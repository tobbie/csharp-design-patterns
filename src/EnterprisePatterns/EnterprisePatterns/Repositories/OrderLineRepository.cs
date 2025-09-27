using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterprisePatterns.DbContexts;
using EnterprisePatterns.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnterprisePatterns.Repositories
{
    public class OrderLineRepository : GenericEFCoreRepository<OrderLine>, IOrderLineRepository
    {
        private readonly OrderDbContext _orderDbContext;

        public OrderLineRepository(OrderDbContext orderDbContext)
            :base(orderDbContext)
        {
            _orderDbContext = orderDbContext;
        }

        public async Task<IEnumerable<OrderLine>> GetAllByOrderId(int orderId)
        {
            return await _orderDbContext.OrderLines
                           .Where(o => o.OrderId == orderId)
                             .ToListAsync();
        }
    }


    // You don't want to do this

    //public class OrderLineRepository : IOrderLineRepository
    //{
    //    private readonly OrderDbContext _orderDbContext;

    //    public OrderLineRepository(OrderDbContext orderDbContext)
    //    {
    //       _orderDbContext = orderDbContext;
    //    }
       
       
    //    public void Add(OrderLine entity)
    //    {
    //       _orderDbContext.OrderLines.Add(entity);
    //    }

    //    public void Delete(OrderLine entity)
    //    {
    //       _orderDbContext.OrderLines.Remove(entity);
    //    }

    //    public async Task<IEnumerable<OrderLine>> GetAll(int id)
    //    {
    //        return await _orderDbContext.OrderLines.ToListAsync();
    //    }

    //    public async Task<IEnumerable<OrderLine>> GetAllByOrderId(int orderId)
    //    {
    //       return await _orderDbContext.OrderLines
    //                        .Where(o => o.OrderId == orderId)
    //                        .ToListAsync();    
    //    }

    //    public async Task<OrderLine?> GetById(int id)
    //    {
    //       return await _orderDbContext.
    //                    OrderLines
    //                    .FirstOrDefaultAsync( o => o.Id == id);
    //    }

    //    public async Task SaveChanges()
    //    {
    //      await  _orderDbContext.SaveChangesAsync();
    //    }

    //    public void Update(OrderLine entity)
    //    {
    //        //no code here.
    //    }
    //}
}
