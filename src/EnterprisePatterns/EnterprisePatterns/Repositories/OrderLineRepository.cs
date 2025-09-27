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

}
