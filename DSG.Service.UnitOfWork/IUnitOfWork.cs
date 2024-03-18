using DSG.Service.Repositories;

namespace DSG.Service.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        IUserRepository Users{ get; } 

        Task<int> SaveChangesAsync();
    }
}
