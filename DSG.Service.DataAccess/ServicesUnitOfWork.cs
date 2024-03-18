using DSG.Service.Persistence;
using DSG.Service.Repositories;
using DSG.Service.UnitOfWork;

namespace DSG.Service.DataAccess
{
    public class ServicesUnitOfWork : IUnitOfWork
    {
        private readonly DSGContext _DSGContext;
        public ServicesUnitOfWork(DSGContext DSGContext) 
        { 
            _DSGContext = DSGContext;
            Users=new UserRepository(DSGContext);
        }
        public IUserRepository Users { get; private set; }

        public async Task<int> SaveChangesAsync() => await _DSGContext.SaveChangesAsync();
            
        
        public void Dispose()
        {
            _DSGContext.Dispose();
        }

       
    }
}
