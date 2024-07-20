using ApiVentas.Models;

namespace ApiVentas.Interfaces
{
    public interface ICiudad
    {
        Task<Respuesta> GetCiudad(int ciudadID, string? ciudadNombre, int? paisID);
        Task<Respuesta> PostCiudad(Ciudad ciudad);
        Task<Respuesta> PutCiudad(Ciudad ciudad);
        Task<Respuesta> DeleteCiudad(Ciudad ciudad);
    }
}
