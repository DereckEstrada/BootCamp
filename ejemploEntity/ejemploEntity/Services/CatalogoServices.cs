using ejemploEntity.Interfaces;
using ejemploEntity.Models;
using Microsoft.EntityFrameworkCore;

namespace ejemploEntity.Services
{
    public class CatalogoServices : ICatalogo
    {
        public readonly TestContext _context;

        public CatalogoServices(TestContext context)
        {
            this._context = context;
        }

        public async Task<Respuesta> getCategoria(int catalogoId)
        {
            var resp = new Respuesta();
            var qry = _context.Categoria;

            try
            {
                if (catalogoId == 0)
                {
                    resp.data = await qry.ToListAsync();
                }
                else
                {
                    resp.data = await qry.Where(x => x.CategId == catalogoId).ToListAsync();
                }

                resp.code = "200";
                resp.mensaje = "Exito!";
            }
            catch (Exception ex)
            {
                resp.code = "400";
                resp.mensaje = $"Error catalogo services: {ex.Message}";
            }

            return resp;
        }
    }
}
