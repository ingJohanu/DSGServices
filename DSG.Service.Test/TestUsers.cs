using DSG.Service.DataAccess;
using DSG.Service.Models;
using DSG.Service.Persistence;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Microsoft.EntityFrameworkCore.InMemory;

namespace DSG.Service.Test
{
    public class TestUsers
    {
        [Test]
        public async Task FindUserById_WithValidId_ReturnsUser()
        {
            // Configurar una base de datos en memoria para las pruebas
            var options = new DbContextOptionsBuilder<DSGContext>()
                .UseInMemoryDatabase(databaseName: "TestDB")
                .Options;

            // Agregar datos de usuario al contexto de la base de datos en memoria
            using (var context = new DSGContext(options))
            {
                context.Users.Add(new Users { IdUser = 1, FirstName = "John", FirstLastName = "Doe",SecundName="Diego",SecundLastName="miguel",
                                                Salary=100,BirthDate=DateTime.Now,CreationDate=DateTime.Now,ModificationDate=DateTime.Now
                });
                await context.SaveChangesAsync();
            }

            // Crear una instancia del servicio de usuarios
            using (var context = new DSGContext(options))
            {
                var service = new UserRepository(context);

                // Ejecutar el método bajo prueba
                var result = await service.FindById(1);

                // Verificar que el resultado no sea nulo y que contenga los datos correctos del usuario
                Assert.NotNull(result);
               
            }
        }
    }
}
