using ApiVentas.Interfaces;
using ApiVentas.Models;
using ApiVentas.Utilitarios;
using Microsoft.AspNetCore.Mvc;
namespace ApiVentas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : Controller
    {
        private readonly ICliente _cliente;
        private ControlError Log = new ControlError();

        public ClienteController(ICliente cliente)
        {
            this._cliente = cliente;
        }

        [HttpGet]
        [Route("GetCliente")]
        public async Task<Respuesta> GetCliente(double clienteID, string? clienteNombre, double cedula)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _cliente.GetCliente(clienteID, clienteNombre, cedula);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("ClienteController", "GetCliente", ex.Message);
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
            }
            return respuesta;
        }

        [HttpPost]
        [Route("PostCliente")]
        public async Task<Respuesta> PostCliente([FromBody] Cliente cliente)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _cliente.PostCliente(cliente);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("ClienteController", "PostCliente", ex.Message);
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
            }
            return respuesta;
        }

        [HttpPut]
        [Route("PutCliente")]
        public async Task<Respuesta> PutCliente([FromBody] Cliente cliente)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _cliente.PutCliente(cliente);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("ClienteController", "PutCliente", ex.Message);
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
            }
            return respuesta;
        }

        [HttpPut]
        [Route("DeleteCliente")]
        public async Task<Respuesta> DeleteCliente([FromBody] Cliente cliente)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _cliente.DeleteCliente(cliente);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("ClienteController", "DeleteCliente", ex.Message);
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
            }
            return respuesta;
        }
    }
}
