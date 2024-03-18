using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSG.Service.Persistence
{
    public static class DataBaseConnections
    {
        public static void AddSqlServer(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DSGContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
        }
    }
}
