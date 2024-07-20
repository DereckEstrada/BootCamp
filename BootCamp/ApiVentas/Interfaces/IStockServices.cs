using ApiVentas.Models;
using ApiVentas.Utilitarios;

namespace ApiVentas.Interfaces
{
    public interface IStockServices
    {
        Task<Respuesta> GetStock(string? opcion, string? data, string? data2);
        Task<Respuesta> PostStock(Stock stock);
        Task<Respuesta> PutStock(Stock stock);
        Task<Respuesta> DeleteStock(int id);
    }
}
