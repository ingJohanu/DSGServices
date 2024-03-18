using System.Collections.Generic;
namespace DSG.Service.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> Delete(T entity);
        Task<T> Update(T entity);
        Task<T> Insert(T entity);
        Task<IEnumerable<T>> GetList();
        Task<T?> GetById(int id);
    }
}
