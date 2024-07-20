using ejemploEntity.Interfaces;
using ejemploEntity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ejemploEntity.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : Controller
    {
        private readonly ICliente _cliente;

        public ClienteController(ICliente cliente)
        {
            _cliente = cliente;
        }

        [HttpGet]
        [Route("getListaClientes")]
        public async Task<Respuesta> getListaClientes(int clienteId, string? nombreCliente, Double identificacion)
        {
            var resp = new Respuesta();

            try
            {
                resp = await _cliente.getListaClientes(clienteId, nombreCliente, identificacion);
            }
            catch (Exception ex)
            {
                resp.code = "400";
                resp.mensaje = $"Error en ClienteController: {ex.Message}";
            }

            return resp;
        }

        [HttpPost]
        [Route("postCliente")]
        public async Task<Respuesta> postCliente([FromBody] Cliente cliente)
        {
            var resp = new Respuesta();

            try
            {
                resp = await _cliente.postCliente(cliente);
            }
            catch (Exception ex)
            {
                resp.code = "400";
                resp.mensaje = $"Error en ClienteController: {ex.Message}";
            }

            return resp;
        }

        [HttpPut]
        [Route("putCliente")]
        public async Task<Respuesta> putCliente([FromBody] Cliente cliente)
        {
            var resp = new Respuesta();

            try
            {
                resp = await _cliente.putCliente(cliente);
            }
            catch (Exception ex)
            {
                resp.code = "400";
                resp.mensaje = $"Error en ClienteController: {ex.Message}";
            }

            return resp;
        }

    }
}
