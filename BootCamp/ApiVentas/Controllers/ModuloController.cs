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
    public class ModuloController : Controller
    {
        private readonly IModulo _Modulo;
        public ControlError err = new ControlError();
        public string clase = "ModuloController";

        public ModuloController(IModulo Modulo)
        {
            _Modulo = Modulo;
        }

        [HttpGet]
        [Route("getListaModulo")]
        public async Task<Respuesta> getListaModulo(int ModuloId, string? nombreModulo)
        {
            var resp = new Respuesta();
            var metodo = "getListaModulos";

            try
            {
                resp = await _Modulo.getListaModulo(ModuloId, nombreModulo);
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
        [Route("postModulo")]
        public async Task<Respuesta> postModulo([FromBody] Modulo Modulo)
        {
            var resp = new Respuesta();
            var metodo = "postModulo";

            try
            {
                resp = await _Modulo.postModulo(Modulo);
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
        [Route("putModulo")]
        public async Task<Respuesta> putModulo([FromBody] Modulo Modulo)
        {
            var resp = new Respuesta();
            var metodo = "putModulo";

            try
            {
                resp = await _Modulo.putModulo(Modulo);
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
        [Route("deleteModulo")]
        public async Task<Respuesta> deleteModulo(int ModuloId)
        {
            var resp = new Respuesta();
            var metodo = "deleteModulo";

            try
            {
                resp = await _Modulo.deleteModulo(ModuloId);
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
