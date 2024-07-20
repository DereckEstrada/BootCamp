using ApiVentas.Interfaces;
using ApiVentas.Models;
using ApiVentas.Utilitarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ApiVentas.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoServices _producto;
        private ControlError log = new ControlError();
        public ProductoController(IProductoServices producto)
        {
            this._producto = producto;
        }
        [HttpGet]
        [Route("GetProducto")]
        public async Task<Respuesta> GetProducto(string? opcion, string? data, string? data2)
        {
            var result = new Respuesta();
            try
            {
                result = await _producto.GetProducto(opcion, data, data2);
            }
            catch (Exception ex)
            {
                log.LogError(this.GetType().Name, "GetProducto", ex.Message);
            }
            return result;
        }
        [HttpPost]
        [Route("PostProducto")]
        public async Task<Respuesta> PostProducto([FromBody] Producto producto)
        {
            var result = new Respuesta();
            try
            {
                result = await _producto.PostProducto(producto);
            }
            catch (Exception ex)
            {
                log.LogError(this.GetType().Name, "PostProducto", ex.Message);
            }
            return result;
        }
        [HttpPut]
        [Route("PutProducto")]
        public async Task<Respuesta> PutProducto([FromBody] Producto producto)
        {
            var result = new Respuesta();
            try
            {
                result = await _producto.PutProducto(producto);
            }
            catch (Exception ex)
            {
                log.LogError(this.GetType().Name, "PutProducto", ex.Message);
            }
            return result;
        }
        [HttpDelete]
        [Route("DeleteProducto")]
        public async Task<Respuesta> DeleteProducto(int id)
        {
            var result = new Respuesta();
            try
            {
                result = await _producto.DeleteProducto(id);
            }
            catch (Exception ex)
            {
                log.LogError(this.GetType().Name, "DeleteProducto", ex.Message);
            }
            return result;
        }
    }
}
