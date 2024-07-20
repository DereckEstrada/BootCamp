using ApiVentas.Models;

namespace ApiVentas.Interfaces
{
    public interface IPais
    {
        Task<Respuesta> getListaPais(int PaisId, string? nombrePais);
        Task<Respuesta> postPais(Pai Pais);
        Task<Respuesta> putPais(Pai Pais);
        Task<Respuesta> deletePais(int PaisId);
    }
}
