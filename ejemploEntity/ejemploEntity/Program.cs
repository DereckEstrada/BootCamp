using ejemploEntity.Interfaces;
using ejemploEntity.Models;
using ejemploEntity.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<IProducto, ProductoServices>();
builder.Services.AddScoped<ICatalogo, CatalogoServices>();
builder.Services.AddScoped<ICliente, ClienteServices>();

builder.Services.AddDbContext<TestContext>(opciones =>
opciones.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

app.Run();
