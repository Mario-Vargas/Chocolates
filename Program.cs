using Microsoft.EntityFrameworkCore;
using Chocolates.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// OBTENEMOS LA CADENA DE CONEXION
var connectionString = builder.Configuration.GetConnectionString("cadenaSQL");

// AGREGANDO LA CONFIGURACION PARA SQL
builder.Services.AddDbContext<DbChocolatesContext>(options =>
options.UseSqlServer(connectionString));

//Definimos la nueva polituca CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
               builder =>
               {
                   builder.WithOrigins("*");
                   builder.WithHeaders("*");
                   builder.WithMethods("*");
               });
});
builder.Services.AddCors(options => options.AddPolicy
("NuevaPolitica", app =>
{
    app.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
}));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Activamos la politica CORS
app.UseCors("NuevaPolitica");

app.UseAuthorization();

app.MapControllers();

app.Run();