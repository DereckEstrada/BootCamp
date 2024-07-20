using ApiVentas.Models;

namespace ApiVentas.Interfaces
{
    public interface IIndustria
    {
        Task<Respuesta> GetIndustria(int industriaID, string? industriaDescripcion);
        Task<Respuesta> PostIndustria(Industrium industria);
        Task<Respuesta> PutIndustria(Industrium industria);
        Task<Respuesta> DeleteIndustria(Industrium industria);
    }
}
