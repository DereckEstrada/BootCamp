using ApiVentas.Interfaces;
using ApiVentas.Models;
using ApiVentas.Utilitarios;
using Microsoft.AspNetCore.Mvc;

namespace ApiVentas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmpresaController : Controller
    {
        private readonly IEmpresa _empresa;
        private ControlError Log = new ControlError();

        public EmpresaController(IEmpresa empresa)
        {
            this._empresa = empresa;
        }

        [HttpGet]
        [Route("GetEmpresa")]
        public async Task<Respuesta> GetEmpresa(int empresaID, string? empresaNombre, string? ruc, int? ciudadID)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _empresa.GetEmpresa(empresaID, empresaNombre, ruc, ciudadID);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("EmpresaController", "GetEmpresa", ex.Message);
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
            }
            return respuesta;
        }

        [HttpPost]
        [Route("PostEmpresa")]
        public async Task<Respuesta> PostEmpresa([FromBody] Empresa empresa)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _empresa.PostEmpresa(empresa);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("EmpresaController", "PostEmpresa", ex.Message);
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
            }
            return respuesta;
        }

        [HttpPut]
        [Route("PutEmpresa")]
        public async Task<Respuesta> PutEmpresa([FromBody] Empresa empresa)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _empresa.PutEmpresa(empresa);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("EmpresaController", "PutEmpresa", ex.Message);
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
            }
            return respuesta;
        }

        [HttpPut]
        [Route("DeleteEmpresa")]
        public async Task<Respuesta> DeleteEmpresa([FromBody] Empresa empresa)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _empresa.DeleteEmpresa(empresa);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("EmpresaController", "DeleteEmpresa", ex.Message);
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
            }
            return respuesta;
        }
    }
}
