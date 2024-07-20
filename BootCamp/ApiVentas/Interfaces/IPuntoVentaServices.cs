using ApiVentas.Models;
using ApiVentas.Utilitarios;

namespace ApiVentas.Interfaces
{
    public interface IPuntoVentaServices
    {
        Task<Respuesta> GetPuntoVenta(string? opcion, string? data);
        Task<Respuesta> PostPuntoVenta(PuntoVentum puntoVenta);
        Task<Respuesta> PutPuntoVenta(PuntoVentum puntoVenta);
        Task<Respuesta> DeletePuntoVenta(int id);
    }
}
