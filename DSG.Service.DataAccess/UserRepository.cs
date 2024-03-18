using DSG.Service.Models;
using DSG.Service.Persistence;
using DSG.Service.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Azure.Core.HttpHeader;

namespace DSG.Service.DataAccess
{
    public class UserRepository : Repository<Users>, IUserRepository
    {
       private readonly DSGContext _DSGContext;
        //Inyecto la cadena de conexión en el contenedor
        public UserRepository(DSGContext DSGContext):base(DSGContext) {
            _DSGContext = DSGContext;
        }

        public async Task<bool> DeleteUser(int idUser)
        {
            Users? UserDelete = await _DSGContext.Users.FirstOrDefaultAsync(x => x.IdUser ==idUser );
            if (UserDelete != null)
            {
                _DSGContext.Users.Remove(UserDelete);
                await _DSGContext.SaveChangesAsync();
            }
            else
            {
                return false;
            }
            
            return true;
        }

        public async Task<Users> FindById(int id)
        {
            return await _DSGContext.Users.Where(x => x.IdUser == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Users>> FindFisrtNameOrLastName(string FirstName, string LastName, int PageNumber, int PageSize)
        {

            IQueryable<Users> query = _DSGContext.Users;

            // Filtrar por nombre y/o apellido si se proporciona alguno de ellos
            if (!string.IsNullOrEmpty(FirstName) || !string.IsNullOrEmpty(LastName))
            {
                if (!string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName))
                {
                    // Si se proporcionan tanto el nombre como el apellido, buscar por ambos
                    query = query.Where(x => x.FirstName.Contains(FirstName) && x.FirstLastName.Contains(LastName));
                }
                else
                {
                    // Si solo se proporciona uno de ellos, buscar por ese criterio
                    if (!string.IsNullOrEmpty(FirstName))
                    {
                        query = query.Where(x => x.FirstName.Contains(FirstName));
                    }

                    if (!string.IsNullOrEmpty(LastName))
                    {
                        query = query.Where(x => x.FirstLastName.Contains(LastName));
                    }
                }
            }

            // Realizar paginación
            query = query.Skip((PageNumber - 1) * PageSize).Take(PageSize);

            // Ejecutar consulta y devolver resultados
            return await query.ToListAsync();
        }

        public async Task<Users> InsertUser(Users user)
        {
            Result result=new Result();
            Users? UserExist = await _DSGContext.Users.FirstOrDefaultAsync(x => x.IdUser == user.IdUser);
            if (UserExist != null)
            {
                EntityEntry<Users> InsertNewUser;

                InsertNewUser = await _DSGContext.Users.AddAsync(user);
                await _DSGContext.SaveChangesAsync();
                return InsertNewUser.Entity;
            }
            else
            {
                throw new Exception($"El usuario con id:{user.IdUser}  ya existe");
            }
                                    
        }

        public async Task<Users> UpdateUser(Users user)
        {
            Users? UserUpdate=await _DSGContext.Users.FirstOrDefaultAsync(x=>x.IdUser==user.IdUser);
            if(UserUpdate!=null)
            {
                UserUpdate.FirstName = user.FirstName;
                UserUpdate.SecundName = user.SecundName;
                UserUpdate.FirstLastName = user.FirstLastName;
                UserUpdate.SecundLastName = user.SecundLastName;
                UserUpdate.BirthDate = user.BirthDate;
                UserUpdate.ModificationDate = DateTime.Now;
                UserUpdate.Salary = user.Salary;
                EntityEntry<Users> UpdateUser = _DSGContext.Users.Update(UserUpdate);
                await _DSGContext.SaveChangesAsync();
                return UpdateUser.Entity;
            }
            else
            {
                throw new Exception($"No se encontro el usuario con id:{user.IdUser}");
            }

           

        }
    }
}
