using DSG.Service.Persistence;
using DSG.Service.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSG.Service.DataAccess
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DSGContext _DSGContext;
        //Inyecto la cadena de conexión en el contenedor
        public Repository(DSGContext DSGContext) 
        {
            _DSGContext = DSGContext;
        }

        protected DbSet<T> EntitySet { get
        {
            return _DSGContext.Set<T>();
        }}

        public Task<T> Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<T?> GetById(int id)
        {
            
            return await EntitySet.FirstOrDefaultAsync();
        }

        public Task<IEnumerable<T>> GetList()
        {
            throw new NotImplementedException();
        }

        public Task<T> Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
