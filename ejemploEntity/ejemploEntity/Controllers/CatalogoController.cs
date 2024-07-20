using ejemploEntity.Interfaces;
using ejemploEntity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ejemploEntity.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogoController : Controller
    {
        private readonly ICatalogo _catalogo;

        public CatalogoController(ICatalogo catalogo)
        {
            this._catalogo = catalogo;
        }

        [HttpGet]
        [Route("getCategoria")]
        public async Task<Respuesta> getCategoria(int catalogoId)
        {
            var resp = new Respuesta();

            try
            {
                resp = await _catalogo.getCategoria(catalogoId);
            }
            catch (Exception ex)
            {

                throw;
            }

            return resp;
        }
    }
}
