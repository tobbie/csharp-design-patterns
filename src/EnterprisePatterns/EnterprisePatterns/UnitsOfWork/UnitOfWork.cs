using System;

using EnterprisePatterns.DbContexts;

namespace EnterprisePatterns.UnitsOfWork
{
    public abstract class UnitOfWork : IUnitOfWork
    {
        private readonly OrderDbContext _dbContext;

        protected UnitOfWork(OrderDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void RollBack()
        {
            _dbContext.ChangeTracker.Clear();
        }
    }
}
