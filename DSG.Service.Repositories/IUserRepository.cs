using DSG.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSG.Service.Repositories
{
    public interface IUserRepository:IRepository<Users>
    {
        Task<IEnumerable<Users>> FindFisrtNameOrLastName(string? FirstName,string? LastName,int PageNumber,int PageSize);

        Task<Users> FindById(int id);

        Task<Users> InsertUser(Users user);

        Task<Users> UpdateUser(Users user);

        Task<bool> DeleteUser(int user);

    }
}
