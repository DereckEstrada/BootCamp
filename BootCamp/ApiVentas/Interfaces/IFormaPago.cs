using ApiVentas.Models;

namespace ApiVentas.Interfaces
{
    public interface IFormaPago
    {
        Task<Respuesta> GetFormaPago(int fpagoID, string? fpagoDescripcion);
        Task<Respuesta> PostFormaPago(FormaPago formaPago);
        Task<Respuesta> PutFormaPago(FormaPago formaPago);
        Task<Respuesta> DeleteFormaPago(FormaPago formaPago);
    }
}