using DSG.Service.DataAccess;
using DSG.Service.Models;
using DSG.Service.Persistence;
using DSG.Service.Repositories;
using DSG.Service.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Net;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Deshabilitar la validación del certificado SSL

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Inyectamos la cadena de conexión que utilizará el context DSGContext
//builder.Services.AddSqlServer(builder.Configuration.GetConnectionString("SQLConnection"));
builder.Services.AddDbContext<DSGContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SQLConnection"));
});

builder.Services.AddScoped<IUnitOfWork, ServicesUnitOfWork>();
builder.Services.AddScoped<IRepository<Users>, Repository<Users>>();

var app = builder.Build();
//Genera automaticamente la base de datos
using (var scope = app.Services.CreateScope())
{
    var DSGContext=scope.ServiceProvider.GetRequiredService<DSGContext>();
    DSGContext.Database.Migrate();

};


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
