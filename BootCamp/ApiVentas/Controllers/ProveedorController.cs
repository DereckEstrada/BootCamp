using ApiVentas.Interfaces;
using ApiVentas.Models;
using ApiVentas.Utilitarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiVentas.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private readonly IProveedorServices _proveedor;
        private ControlError log = new ControlError();
        public ProveedorController(IProveedorServices proveedor)
        {
            this._proveedor = proveedor;
        }
        [HttpGet]
        [Route("GetProveedor")]
        public async Task<Respuesta> GetProveedor(string? opcion, string? data)
        {
            var result = new Respuesta();
            try
            {
                result = await _proveedor.GetProveedor(opcion, data);
            }
            catch (Exception ex)
            {
                log.LogError(this.GetType().Name, "GetProveedor", ex.Message);
            }
            return result;
        }
        [HttpPost]
        [Route("PostProveedor")]
        public async Task<Respuesta> PostProveedor([FromBody] Proveedor proveedor)
        {
            var result = new Respuesta();
            try
            {
                result = await _proveedor.PostProveedor(proveedor);
            }
            catch (Exception ex)
            {
                log.LogError(this.GetType().Name, "PostProveedor", ex.Message);
            }
            return result;
        }
        [HttpPut]
        [Route("PutProveedor")]
        public async Task<Respuesta> PutProveedor([FromBody] Proveedor proveedor)
        {
            var result = new Respuesta();
            try
            {
                result = await _proveedor.PutProveedor(proveedor);
            }
            catch (Exception ex)
            {
                log.LogError(this.GetType().Name, "PutProveedor", ex.Message);
            }
            return result;
        }
        [HttpDelete]
        [Route("DeleteProveedor")]
        public async Task<Respuesta> DeleteProveedor(int id)
        {
            var result = new Respuesta();
            try
            {
                result = await _proveedor.DeleteProveedor(id);
            }
            catch (Exception ex)
            {
                log.LogError(this.GetType().Name, "DeleteProveedor", ex.Message);
            }
            return result;
        }
    }
}
