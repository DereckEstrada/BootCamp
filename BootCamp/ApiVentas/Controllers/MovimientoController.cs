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
    public class MovimientoController : Controller
    {
        private readonly IMovimiento _Movimiento;
        public ControlError err = new ControlError();
        public string clase = "MovimientoController";

        public MovimientoController(IMovimiento Movimiento)
        {
            _Movimiento = Movimiento;
        }

        [HttpGet]
        [Route("getListaMovimiento")]
        public async Task<Respuesta> getListaMovimiento(int tipoConsulta, string? SecuenciaFactura, string? Cliente, string? Proveedor)
        {
            var resp = new Respuesta();
            var metodo = "getListaMovimientos";

            try
            {
                resp = await _Movimiento.getListaMovimiento(tipoConsulta, SecuenciaFactura, Cliente, Proveedor);
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
        [Route("postMovimiento")]
        public async Task<Respuesta> postMovimiento([FromBody] MovimientoCab Movimiento)
        {
            var resp = new Respuesta();
            var metodo = "postMovimiento";

            try
            {
                resp = await _Movimiento.postMovimiento(Movimiento);
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
        [Route("putMovimiento")]
        public async Task<Respuesta> putMovimiento([FromBody] MovimientoCab Movimiento)
        {
            var resp = new Respuesta();
            var metodo = "putMovimiento";

            try
            {
                resp = await _Movimiento.putMovimiento(Movimiento);
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
        [Route("deleteMovimiento")]
        public async Task<Respuesta> deleteMovimiento(int MovimientoId)
        {
            var resp = new Respuesta();
            var metodo = "deleteMovimiento";

            try
            {
                resp = await _Movimiento.deleteMovimiento(MovimientoId);
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
