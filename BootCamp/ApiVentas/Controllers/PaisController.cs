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
    public class PaisController : Controller
    {
        private readonly IPais _Pais;
        public ControlError err = new ControlError();
        public string clase = "PaisController";

        public PaisController(IPais Pais)
        {
            _Pais = Pais;
        }

        [HttpGet]
        [Route("getListaPais")]
        public async Task<Respuesta> getListaPais(int PaisId, string? nombrePais)
        {
            var resp = new Respuesta();
            var metodo = "getListaPaiss";

            try
            {
                resp = await _Pais.getListaPais(PaisId, nombrePais);
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
        [Route("postPais")]
        public async Task<Respuesta> postPais([FromBody] Pai Pais)
        {
            var resp = new Respuesta();
            var metodo = "postPais";

            try
            {
                resp = await _Pais.postPais(Pais);
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
        [Route("putPais")]
        public async Task<Respuesta> putPais([FromBody] Pai Pais)
        {
            var resp = new Respuesta();
            var metodo = "putPais";

            try
            {
                resp = await _Pais.putPais(Pais);
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
        [Route("deletePais")]
        public async Task<Respuesta> deletePais(int PaisId)
        {
            var resp = new Respuesta();
            var metodo = "deletePais";

            try
            {
                resp = await _Pais.deletePais(PaisId);
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
