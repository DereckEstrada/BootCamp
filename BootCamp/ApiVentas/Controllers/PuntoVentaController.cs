using ApiVentas.Interfaces;
using ApiVentas.Models;
using ApiVentas.Utilitarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiVentas.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PuntoVentaController : ControllerBase
    {
        private readonly IPuntoVentaServices _puntoVenta;
        private ControlError log = new ControlError();
        public PuntoVentaController(IPuntoVentaServices puntoVenta)
        {
            this._puntoVenta = puntoVenta;
        }
        [HttpGet]
        [Route("GetPuntoVenta")]
        public async Task<Respuesta> GetPuntoVenta(string? opcion, string? data, string? data2)
        {
            var result = new Respuesta();
            try
            {
                result = await _puntoVenta.GetPuntoVenta(opcion, data);
            }
            catch (Exception ex)
            {
                log.LogError(this.GetType().Name, "GetPuntoVenta", ex.Message);
            }
            return result;
        }
        [HttpPost]
        [Route("PostPuntoVenta")]
        public async Task<Respuesta> PostPuntoVenta([FromBody] PuntoVentum puntoVenta)
        {
            var result = new Respuesta();
            try
            {
                result = await _puntoVenta.PostPuntoVenta(puntoVenta);
            }
            catch (Exception ex)
            {
                log.LogError(this.GetType().Name, "PostPuntoVenta", ex.Message);
            }
            return result;
        }
        [HttpPut]
        [Route("PutPuntoVenta")]
        public async Task<Respuesta> PutPuntoVenta([FromBody] PuntoVentum puntoVenta)
        {
            var result = new Respuesta();
            try
            {
                result = await _puntoVenta.PutPuntoVenta(puntoVenta);
            }
            catch (Exception ex)
            {
                log.LogError(this.GetType().Name, "PutPuntoVenta", ex.Message);
            }
            return result;
        }
        [HttpDelete]
        [Route("DeletePuntoVenta")]
        public async Task<Respuesta> DeletePuntoVenta(int id)
        {
            var result = new Respuesta();
            try
            {
                result = await _puntoVenta.DeletePuntoVenta(id);
            }
            catch (Exception ex)
            {
                log.LogError(this.GetType().Name, "DeletePuntoVenta", ex.Message);
            }
            return result;
        }
    }
}
