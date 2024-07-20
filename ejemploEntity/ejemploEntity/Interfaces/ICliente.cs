using ejemploEntity.Models;
using Microsoft.AspNetCore.Mvc;

namespace ejemploEntity.Interfaces
{
    public interface ICliente
    {
        Task<Respuesta> getListaClientes(int clienteId, string? nombreCliente, Double identificacion);
        Task<Respuesta> postCliente(Cliente cliente);
        Task<Respuesta> putCliente(Cliente cliente);
    }
}
