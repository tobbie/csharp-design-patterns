using System;

using EnterprisePatterns.DbContexts;
using EnterprisePatterns.Repositories;

namespace EnterprisePatterns.UnitsOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OrderDbContext _dbContext;
        private readonly Dictionary<Type, object> _repositories = new();

        public UnitOfWork(OrderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IRepository<T> Repository<T>() where T : class
        {
            if (_repositories.ContainsKey(typeof(T)))
            {
                return (IRepository<T>)_repositories[typeof(T)];
            }

            var repoInstance = new GenericEFCoreRepository<T>(_dbContext);
            _repositories.Add(typeof(T), repoInstance);
            return repoInstance;
        }

        public async Task<int> CommitAsync() => await _dbContext.SaveChangesAsync();

        public void Rollback() => _dbContext.ChangeTracker.Clear();

       // public async ValueTask DisposeAsync() => await _dbContext.DisposeAsync();
    }


    //public abstract class UnitOfWork : IUnitOfWork
    //{
    //    private readonly OrderDbContext _dbContext;

    //    protected UnitOfWork(OrderDbContext dbContext)
    //    {
    //        _dbContext = dbContext;
    //    }
    //    public async Task CommitAsync()
    //    {
    //        await _dbContext.SaveChangesAsync();
    //    }

    //    public void RollBack()
    //    {
    //        _dbContext.ChangeTracker.Clear();
    //    }
    //}
}
