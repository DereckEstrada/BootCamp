using ApiVentas.Interfaces;
using ApiVentas.Models;
using ApiVentas.Utilitarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiVentas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BodegaController : Controller
    {
        private readonly IBodega _bodega;
        private ControlError Log = new ControlError();

        public BodegaController(IBodega bodega)
        {
            this._bodega = bodega;
        }

        [HttpGet]
        [Route("GetBodega")]
        public async Task<Respuesta> GetBodega(int bodegaID, string? bodegaNombre, string? bodegaTelefono)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _bodega.GetBodega(bodegaID, bodegaNombre, bodegaTelefono);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("BodegaController", "GetBodega", ex.Message);
            }
            return respuesta;
        }

        [HttpPost]
        [Route("PostBodega")]
        public async Task<Respuesta> PostBodega([FromBody] Bodega bodega)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _bodega.PostBodega(bodega);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("BodegaController", "PostBodega", ex.Message);
            }
            return respuesta;
        }
        [HttpPut]
        [Route("PutBodega")]
        public async Task<Respuesta> PutBodega([FromBody] Bodega bodega)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _bodega.PutBodega(bodega);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("BodegaController", "PutBodega", ex.Message);
            }
            return respuesta;
        }

        [HttpPut]
        [Route("DeleteBodega")]
        public async Task<Respuesta> DeleteBodega([FromBody] Bodega bodega)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _bodega.DeleteBodega(bodega);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("BodegaController", "DeleteBodega", ex.Message);
            }
            return respuesta;
        }
    }
}
