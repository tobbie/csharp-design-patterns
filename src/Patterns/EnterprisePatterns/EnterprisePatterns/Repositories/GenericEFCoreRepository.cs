using System;
using System.Collections.Generic;
using System.Linq;

using EnterprisePatterns.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace EnterprisePatterns.Repositories
{
    public class GenericEFCoreRepository<T> : IRepository<T> where T : class
    {
        private readonly OrderDbContext _dbContext;
        private DbSet<T> _dbSet;
        public GenericEFCoreRepository(OrderDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Delete(T entity)
        {
           _dbSet.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
;        }

        public async Task<T?> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        //should not be on repo if uow pattern is used.
        public async Task SaveChanges()
        {  
            await _dbContext.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            //no code required.
            //_dbcontext tracks automatically entities
        }
    }
}
