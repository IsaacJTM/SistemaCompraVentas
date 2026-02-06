using ComprasVentas.Data;
using ComprasVentas.Models;
using ComprasVentas.Repository;
using ComprasVentas.Servicios;
using ComprasVentas.Servicios.impl;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString);
});

//2. Registrar los servicios
builder.Services.AddScoped<IPermisoServices, PermisoServices>();
builder.Services.AddScoped<IRolServices, RolServices>();

//3. Registrar los repositorios
builder.Services.AddScoped<PermisoRepository>();
builder.Services.AddScoped<RolRepository>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
