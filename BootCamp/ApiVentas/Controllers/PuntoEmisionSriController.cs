using ApiVentas.Interfaces;
using ApiVentas.Models;
using ApiVentas.Utilitarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiVentas.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PuntoEmisionSriController : ControllerBase
    {
        private readonly IPuntoEmisionSriServices _punto;
        private ControlError log = new ControlError();
        public PuntoEmisionSriController(IPuntoEmisionSriServices punto)
        {
            this._punto = punto;
        }
        [HttpGet]
        [Route("GetPuntoEmisionSri")]
        public async Task<Respuesta> GetPuntoEmisionSri(string? opcion, string? data)
        {
            var result = new Respuesta();
            try
            {
                result = await _punto.GetPuntoEmisionSri(opcion, data);
            }
            catch (Exception ex)
            {
                log.LogError(this.GetType().Name, "GetPuntoEmisionSri", ex.Message);
            }
            return result;
        }
        [HttpPost]
        [Route("PostPuntoEmisionSri")]
        public async Task<Respuesta> PostPuntoEmisionSri([FromBody] PuntoEmisionSri emisionSri)
        {
            var result = new Respuesta();
            try
            {
                result = await _punto.PostPuntoEmisionSri(emisionSri);
            }
            catch (Exception ex)
            {
                log.LogError(this.GetType().Name, "PostPuntoEmisionSri", ex.Message);
            }
            return result;
        }
        [HttpPut]
        [Route("PutPuntoEmisionSri")]
        public async Task<Respuesta> PutPuntoEmisionSri([FromBody] PuntoEmisionSri emisionSri)
        {
            var result = new Respuesta();
            try
            {
                result = await _punto.PutPuntoEmisionSri(emisionSri);
            }
            catch (Exception ex)
            {
                log.LogError(this.GetType().Name, "PutPuntoEmisionSri", ex.Message);
            }
            return result;
        }
        [HttpDelete]
        [Route("DeletePuntoEmisionSri")]
        public async Task<Respuesta> DeletePuntoEmisionSri(int id)
        {
            var result = new Respuesta();
            try
            {
                result = await _punto.DeletePuntoEmisionSri(id);
            }
            catch (Exception ex)
            {
                log.LogError(this.GetType().Name, "DeletePuntoEmisionSri", ex.Message);
            }
            return result;
        }
    }
}
