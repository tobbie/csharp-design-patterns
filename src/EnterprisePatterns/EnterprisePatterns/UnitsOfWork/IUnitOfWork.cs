using EnterprisePatterns.Repositories;

namespace EnterprisePatterns.UnitsOfWork
{

    public interface IUnitOfWork
    {
        IRepository<T> Repository<T>() where T : class;
        Task<int> CommitAsync();
        void Rollback();
    }


    //public interface IUnitOfWork
    //{
    //    Task CommitAsync();
    //    void RollBack();

    //}
}
