using ejemploEntity.Models;
using Microsoft.AspNetCore.Mvc;

namespace ejemploEntity.Interfaces
{
    public interface IProducto
    {
        Task<Respuesta> getListaProductos(int productoId, double precio);
        Task<Respuesta> PostProducto(Producto producto);
        Task<Respuesta> PutProducto(Producto producto);
        Task<Respuesta> PutProducto2(Producto producto, int productoId);
    }
}
