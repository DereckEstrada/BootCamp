using ApiVentas.Interfaces;
using ApiVentas.Models;
using ApiVentas.Utilitarios;
using Microsoft.AspNetCore.Mvc;

namespace ApiVentas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CiudadController : Controller
    {
        private readonly ICiudad _ciudad;
        private ControlError Log = new ControlError();

        public CiudadController(ICiudad ciudad)
        {
            this._ciudad = ciudad;
        }

        [HttpGet]
        [Route("GetCiudad")]
        public async Task<Respuesta> GetCiudad(int ciudadID, string? ciudadNombre, int? paisID)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _ciudad.GetCiudad(ciudadID, ciudadNombre, paisID);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CiudadController", "GetCiudad", ex.Message);
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
            }
            return respuesta;
        }

        [HttpPost]
        [Route("PostCiudad")]
        public async Task<Respuesta> PostCiudad([FromBody] Ciudad ciudad)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _ciudad.PostCiudad(ciudad);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CiudadController", "PostCiudad", ex.Message);
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
            }
            return respuesta;
        }

        [HttpPut]
        [Route("PutCiudad")]
        public async Task<Respuesta> PutCiudad([FromBody] Ciudad ciudad)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _ciudad.PutCiudad(ciudad);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CiudadController", "PutCiudad", ex.Message);
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
            }
            return respuesta;
        }

        [HttpPut]
        [Route("DeleteCiudad")]
        public async Task<Respuesta> DeleteCiudad([FromBody] Ciudad ciudad)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _ciudad.DeleteCiudad(ciudad);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CiudadController", "DeleteCiudad", ex.Message);
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
            }
            return respuesta;
        }
    }
}
