using ApiVentas.Models;

namespace ApiVentas.Interfaces
{
    public interface IModulo
    {
        Task<Respuesta> getListaModulo(int ModuloId, string? nombreModulo);
        Task<Respuesta> postModulo(Modulo Modulo);
        Task<Respuesta> putModulo(Modulo Modulo);
        Task<Respuesta> deleteModulo(int ModuloId);
    }
}
