using DSG.Service.Models;
using DSG.Service.Persistence;
using DSG.Service.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Runtime.CompilerServices;

namespace DSG.Service.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _IUnitoOfWork;
        public UsersController(IUnitOfWork IUnitOfWork)
        {
            _IUnitoOfWork = IUnitOfWork;
        }
        [HttpGet]
        public async Task<IEnumerable<Users>> FindFisrtNameOrLastName(string FirstName,string? LastName, int PageNumber, int PageSize)
        {
            return await _IUnitoOfWork.Users.FindFisrtNameOrLastName(FirstName,LastName, PageNumber, PageSize);
        }

        [HttpGet("{id}")]
        public async Task<Users> FindById(int id)
        {
            return await _IUnitoOfWork.Users.FindById(id);
        }

        [HttpPost]
        public async Task<Users> Insert(Users user)
        {
            return await _IUnitoOfWork.Users.InsertUser(user);
        }

        [HttpPut]
        public async Task<Users> Update(Users user)
        {
            return await _IUnitoOfWork.Users.UpdateUser(user);
        }

        [HttpDelete]
        public async Task<bool> Delete(int idUser)
        {
            return await _IUnitoOfWork.Users.DeleteUser(idUser);
        }

    }
}
