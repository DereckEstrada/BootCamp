using ApiVentas.Models;

namespace ApiVentas.Interfaces
{
    public interface ICategoria
    {
        Task<Respuesta> GetCategoria(int categoriaID, string? categoriaDescripcion);
        Task<Respuesta> PostCategoria(Categorium categoria);
        Task<Respuesta> PutCategoria(Categorium categoria);
        Task<Respuesta> DeleteCategoria(Categorium categoria);
    }
}
