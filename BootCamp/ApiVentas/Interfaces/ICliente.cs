using ApiVentas.Models;

namespace ApiVentas.Interfaces
{
    public interface ICliente
    {
        Task<Respuesta> GetCliente(double clienteID, string? clienteNombre, double cedula);
        Task<Respuesta> PostCliente(Cliente cliente);
        Task<Respuesta> PutCliente(Cliente cliente);
        Task<Respuesta> DeleteCliente(Cliente cliente);
    }
}