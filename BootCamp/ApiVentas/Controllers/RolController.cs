using ApiVentas.Interfaces;
using ApiVentas.Models;
using ApiVentas.Utilitarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiVentas.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly IRolServices _rol;
        private ControlError log = new ControlError();
        public RolController(IRolServices rol)
        {
            this._rol = rol;
        }
        [HttpGet]
        [Route("GetRol")]
        public async Task<Respuesta> GetRol(string? opcion, string? data, string? data2)
        {
            var result = new Respuesta();
            try
            {
                result = await _rol.GetRol(opcion, data);
            }
            catch (Exception ex)
            {
                log.LogError(this.GetType().Name, "GetRol", ex.Message);
            }
            return result;
        }
        [HttpPost]
        [Route("PostRol")]
        public async Task<Respuesta> PostRol([FromBody] Rol rol)
        {
            var result = new Respuesta();
            try
            {
                result = await _rol.PostRol(rol);
            }
            catch (Exception ex)
            {
                log.LogError(this.GetType().Name, "PostRol", ex.Message);
            }
            return result;
        }
        [HttpPut]
        [Route("PutRol")]
        public async Task<Respuesta> PutRol([FromBody] Rol rol)
        {
            var result = new Respuesta();
            try
            {
                result = await _rol.PutRol(rol);
            }
            catch (Exception ex)
            {
                log.LogError(this.GetType().Name, "PutRol", ex.Message);
            }
            return result;
        }
        [HttpDelete]
        [Route("DeleteRol")]
        public async Task<Respuesta> DeleteRol(int id)
        {
            var result = new Respuesta();
            try
            {
                result = await _rol.DeleteRol(id);
            }
            catch (Exception ex)
            {
                log.LogError(this.GetType().Name, "DeleteRol", ex.Message);
            }
            return result;
        }

    }
}
