using ejemploEntity.Models;

namespace ejemploEntity.Interfaces
{
    public interface ICatalogo
    {
        Task<Respuesta> getCategoria(int catalogoId);
    }
}
