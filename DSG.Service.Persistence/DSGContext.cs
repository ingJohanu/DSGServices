using DSG.Service.Models;
using Microsoft.EntityFrameworkCore;

namespace DSG.Service.Persistence
{
    public class DSGContext:DbContext
    {
       public DSGContext(DbContextOptions<DSGContext> options) :
            base(options) 
       {    
        
       }
        public virtual DbSet<Users> Users { get; set; }
    }
}
