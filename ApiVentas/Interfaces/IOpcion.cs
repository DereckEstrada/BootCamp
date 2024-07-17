using ApiVentas.Models;

namespace ApiVentas.Interfaces
{
    public interface IOpcion
    {
        Task<Respuesta> getListaOpcion(int OpcionId, string? nombreOpcion);
        Task<Respuesta> postOpcion(Opcion Opcion);
        Task<Respuesta> putOpcion(Opcion Opcion);
        Task<Respuesta> deleteOpcion(int OpcionId);
    }
}
