using ApiVentas.Models;
using ApiVentas.Utilitarios;

namespace ApiVentas.Interfaces
{
    public interface IPuntoEmisionSriServices
    {
        Task<Respuesta> GetPuntoEmisionSri(string? opcion, string? data);
        Task<Respuesta> PostPuntoEmisionSri(PuntoEmisionSri emisionSri);
        Task<Respuesta> PutPuntoEmisionSri(PuntoEmisionSri emisionSri);
        Task<Respuesta> DeletePuntoEmisionSri(int id);
    }
}
