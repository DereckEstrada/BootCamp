using ApiVentas.Models;
using ApiVentas.Utilitarios;

namespace ApiVentas.Interfaces
{
    public interface IProveedorServices
    {
        Task<Respuesta> GetProveedor(string? opcion, string? data);
        Task<Respuesta> PostProveedor(Proveedor proveedor);
        Task<Respuesta> PutProveedor(Proveedor proveedor);
        Task<Respuesta> DeleteProveedor(int id);
    }
}
