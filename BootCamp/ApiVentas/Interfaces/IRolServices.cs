using ApiVentas.Models;
using ApiVentas.Utilitarios;

namespace ApiVentas.Interfaces
{
    public interface IRolServices
    {
        Task<Respuesta> GetRol(string? opcion, string? data);
        Task<Respuesta> PostRol(Rol rol);
        Task<Respuesta> PutRol(Rol rol);
        Task<Respuesta> DeleteRol(int id);
    }
}
