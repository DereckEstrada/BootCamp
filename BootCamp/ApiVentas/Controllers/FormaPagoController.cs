using ApiVentas.Interfaces;
using ApiVentas.Models;
using ApiVentas.Utilitarios;
using Microsoft.AspNetCore.Mvc;

namespace ApiVentas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FormaPagoController : Controller
    {
        private readonly IFormaPago _formaPago;
        private ControlError Log = new ControlError();

        public FormaPagoController(IFormaPago formaPago)
        {
            this._formaPago = formaPago;
        }

        [HttpGet]
        [Route("GetFormaPago")]
        public async Task<Respuesta> GetFormaPago(int fpagoID, string? fpagoDescripcion)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _formaPago.GetFormaPago(fpagoID, fpagoDescripcion);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("FormaPagoController", "GetFormaPago", ex.Message);
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
            }
            return respuesta;
        }

        [HttpPost]
        [Route("PostFormaPago")]
        public async Task<Respuesta> PostFormaPago([FromBody] FormaPago formaPago)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _formaPago.PostFormaPago(formaPago);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("FormaPagoController", "PostFormaPago", ex.Message);
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
            }
            return respuesta;
        }

        [HttpPut]
        [Route("PutFormaPago")]
        public async Task<Respuesta> PutFormaPago([FromBody] FormaPago formaPago)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _formaPago.PutFormaPago(formaPago);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("FormaPagoController", "PutFormaPago", ex.Message);
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
            }
            return respuesta;
        }

        [HttpPut]
        [Route("DeleteFormaPago")]
        public async Task<Respuesta> DeleteFormaPago([FromBody] FormaPago formaPago)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _formaPago.DeleteFormaPago(formaPago);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("FormaPagoController", "DeleteFormaPago", ex.Message);
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
            }
            return respuesta;
        }
    }
}
