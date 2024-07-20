using ApiVentas.Interfaces;
using ApiVentas.Models;
<<<<<<< HEAD
using ejemploEntity.Services;
=======
using ApiVentas.Services;
using ApiVentas.Utilitarios;
>>>>>>> 51d753598d72b527e8641099d8c0352deff52358
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
<<<<<<< HEAD

#region "CONTROLADORES"

builder.Services.AddScoped<IPais, PaisServices>();
builder.Services.AddScoped<IModulo, ModuloServices>();
builder.Services.AddScoped<IOpcion, OpcionServices>();
builder.Services.AddScoped<IMovimiento, MovimientoServices>();

#endregion

//builder.Services.AddDbContext<BaseErpContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionDefault")));
builder.Services.AddDbContext<BaseErpContext>(opciones =>
opciones.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
    sqlServerOptionsAction: sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure(
            maxRetryCount: 5,
            maxRetryDelay: TimeSpan.FromSeconds(30),
            errorNumbersToAdd: null
        );
    }
));
var app = builder.Build();
=======
builder.Services.AddScoped<IBodegaServices, BodegaServices>();
builder.Services.AddScoped<IProductoServices, ProductoServices>();
builder.Services.AddScoped<IProveedorServices, ProveedorServices>();
builder.Services.AddScoped<IPuntoEmisionSriServices, PuntoEmisionSriServices>();
builder.Services.AddScoped<IPuntoVentaServices, PuntoVentaServices>();
builder.Services.AddScoped<IRolServices, RolServices>();
builder.Services.AddScoped<IStockServices, StockServices>();
builder.Services.AddScoped<IBodega, BodegaService>();
builder.Services.AddScoped<ICategoria, CategoriaService>();
builder.Services.AddScoped<ICiudad, CiudadService>();
builder.Services.AddScoped<ICliente, ClienteServices>();
builder.Services.AddScoped<IEmpresa, EmpresaService>();
builder.Services.AddScoped<IFormaPago, FormaPagoService>();
builder.Services.AddScoped<IIndustria, IndustriaService>();
builder.Services.AddDbContext<BaseErpContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionDefault")));
var app = builder.Build();
// Configure the HTTP request pipeline.
>>>>>>> 51d753598d72b527e8641099d8c0352deff52358

app.UseAuthorization();

app.MapControllers();

app.Run();
