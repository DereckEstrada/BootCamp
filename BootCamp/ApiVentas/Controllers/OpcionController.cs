using ApiVentas.Interfaces;
using ApiVentas.Models;
using ApiVentas.Utilitarios;
using ApiVentas.Interfaces;
using ApiVentas.Models;
using ApiVentas.Utilitarios;
using Microsoft.AspNetCore.Mvc;

namespace ejemploEntity.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OpcionController : Controller
    {
        private readonly IOpcion _Opcion;
        public ControlError err = new ControlError();
        public string clase = "OpcionController";

        public OpcionController(IOpcion Opcion)
        {
            _Opcion = Opcion;
        }

        [HttpGet]
        [Route("getListaOpcion")]
        public async Task<Respuesta> getListaOpcion(int OpcionId, string? nombreOpcion)
        {
            var resp = new Respuesta();
            var metodo = "getListaOpcions";

            try
            {
                resp = await _Opcion.getListaOpcion(OpcionId, nombreOpcion);
            }
            catch (Exception ex)
            {
                resp.code = "400";
                resp.mensaje = $"Error en {clase}: {ex.Message}";
                err.LogErrorMetodos(clase, metodo, ex.Message);
            }

            return resp;
        }

        [HttpPost]
        [Route("postOpcion")]
        public async Task<Respuesta> postOpcion([FromBody] Opcion Opcion)
        {
            var resp = new Respuesta();
            var metodo = "postOpcion";

            try
            {
                resp = await _Opcion.postOpcion(Opcion);
            }
            catch (Exception ex)
            {
                resp.code = "400";
                resp.mensaje = $"Error en {clase}: {ex.Message}";
                err.LogErrorMetodos(clase, metodo, ex.Message);
            }

            return resp;
        }

        [HttpPut]
        [Route("putOpcion")]
        public async Task<Respuesta> putOpcion([FromBody] Opcion Opcion)
        {
            var resp = new Respuesta();
            var metodo = "putOpcion";

            try
            {
                resp = await _Opcion.putOpcion(Opcion);
            }
            catch (Exception ex)
            {
                resp.code = "400";
                resp.mensaje = $"Error en {clase}: {ex.Message}";
                err.LogErrorMetodos(clase, metodo, ex.Message);
            }

            return resp;
        }

        [HttpDelete]
        [Route("deleteOpcion")]
        public async Task<Respuesta> deleteOpcion(int OpcionId)
        {
            var resp = new Respuesta();
            var metodo = "deleteOpcion";

            try
            {
                resp = await _Opcion.deleteOpcion(OpcionId);
            }
            catch (Exception ex)
            {
                resp.code = "400";
                resp.mensaje = $"Error en {clase}: {ex.Message}";
                err.LogErrorMetodos(clase, metodo, ex.Message);
            }

            return resp;
        }

    }
}
