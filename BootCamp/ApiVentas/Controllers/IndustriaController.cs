using ApiVentas.Interfaces;
using ApiVentas.Models;
using ApiVentas.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ApiVentas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IndustriaController : ControllerBase
    {
        private readonly IIndustria _industria;
        private readonly ControlError Log = new ControlError();

        public IndustriaController(IIndustria industria)
        {
            this._industria = industria;
        }

        [HttpGet]
        [Route("GetIndustria")]
        public async Task<ActionResult<Respuesta>> GetIndustria(int industriaID, string? industriaDescripcion)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _industria.GetIndustria(industriaID, industriaDescripcion);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("IndustriaController", "GetIndustria", ex.Message);
                respuesta.Cod = "999";
                respuesta.Mensaje = "Se presentó una novedad, comunicarse con el departamento de sistemas";
            }
            return respuesta;
        }

        [HttpPost]
        [Route("PostIndustria")]
        public async Task<ActionResult<Respuesta>> PostIndustria([FromBody] Industrium industria)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _industria.PostIndustria(industria);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("IndustriaController", "PostIndustria", ex.Message);
                respuesta.Cod = "999";
                respuesta.Mensaje = "Se presentó una novedad, comunicarse con el departamento de sistemas";
            }
            return respuesta;
        }

        [HttpPut]
        [Route("PutIndustria")]
        public async Task<ActionResult<Respuesta>> PutIndustria([FromBody] Industrium industria)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _industria.PutIndustria(industria);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("IndustriaController", "PutIndustria", ex.Message);
                respuesta.Cod = "999";
                respuesta.Mensaje = "Se presentó una novedad, comunicarse con el departamento de sistemas";
            }
            return respuesta;
        }

        [HttpPut]
        [Route("DeleteIndustria")]
        public async Task<ActionResult<Respuesta>> DeleteIndustria([FromBody] Industrium industria)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _industria.DeleteIndustria(industria);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("IndustriaController", "DeleteIndustria", ex.Message);
                respuesta.Cod = "999";
                respuesta.Mensaje = "Se presentó una novedad, comunicarse con el departamento de sistemas";
            }
            return respuesta;
        }
    }
}
