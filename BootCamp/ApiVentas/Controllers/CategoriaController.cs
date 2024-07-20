using ApiVentas.Interfaces;
using ApiVentas.Models;
using ApiVentas.Utilitarios;
using Microsoft.AspNetCore.Mvc;

namespace ApiVentas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : Controller
    {
        private readonly ICategoria _categoria;
        private ControlError Log = new ControlError();

        public CategoriaController(ICategoria categoria)
        {
            this._categoria = categoria;
        }

        [HttpGet]
        [Route("GetCategoria")]
        public async Task<Respuesta> GetCategoria(int categoriaID, string? categoriaDescripcion)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _categoria.GetCategoria(categoriaID, categoriaDescripcion);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CategoriaController", "GetCategoria", ex.Message);
            }
            return respuesta;
        }

        [HttpPost]
        [Route("PostCategoria")]
        public async Task<Respuesta> PostCategoria([FromBody] Categorium categoria)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _categoria.PostCategoria(categoria);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CategoriaController", "PostCategoria", ex.Message);
            }
            return respuesta;
        }

        [HttpPut]
        [Route("PutCategoria")]
        public async Task<Respuesta> PutCategoria([FromBody] Categorium categoria)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _categoria.PutCategoria(categoria);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CategoriaController", "PutCategoria", ex.Message);
            }
            return respuesta;
        }

        [HttpPut]
        [Route("DeleteCategoria")]
        public async Task<Respuesta> DeleteCategoria([FromBody] Categorium categoria)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _categoria.DeleteCategoria(categoria);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CategoriaController", "DeleteCategoria", ex.Message);
            }

            return respuesta;
        }
    }
}
