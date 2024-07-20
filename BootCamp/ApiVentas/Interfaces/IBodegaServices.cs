using ApiVentas.Models;
using ApiVentas.Utilitarios;

namespace ApiVentas.Interfaces
{
    public interface IBodegaServices
    {
        Task<Respuesta> GetBodega(string? opcion, string? data);
        Task<Respuesta> PostBodega(Bodega bodega);
        Task<Respuesta> PutBodega(Bodega bodega);
        Task<Respuesta> DeleteBodega(int id);
    }
}
