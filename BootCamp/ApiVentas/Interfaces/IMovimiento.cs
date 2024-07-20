using ApiVentas.Models;

namespace ApiVentas.Interfaces
{
    public interface IMovimiento
    {
        Task<Respuesta> getListaMovimiento(int tipoConsulta, string? SecuenciaFactura, string? Cliente, string? Proveedor);
        Task<Respuesta> postMovimiento(MovimientoCab Movimiento);
        Task<Respuesta> putMovimiento(MovimientoCab Movimiento);
        Task<Respuesta> deleteMovimiento(int MovimientoId);
    }
}
