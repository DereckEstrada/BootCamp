using ejemploEntity.Interfaces;
using ejemploEntity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ejemploEntity.Services
{
    public class ProductoServices : IProducto
    {
        public readonly TestContext _context;

        public ProductoServices(TestContext context) { _context = context; }
        public async Task<Respuesta> getListaProductos(int productoId, double precio)
        {
            var resp = new Respuesta();

            var qryPro = _context.Productos;
            var qryMar = _context.Marcas;
            var qryCat = _context.Categoria;
            var qryMod = _context.Modelos;

            try
            {
                if (productoId == 0)
                {
                    //resp = await _context.Productos.ToListAsync();
                    resp.data = await (from p in qryPro
                                       join m in qryMar on p.MarcaId equals m.MarcaId
                                       join c in qryCat on p.CategId equals c.CategId
                                       join mo in qryMod on p.ModeloId equals mo.ModeloId
                                       where p.Estado.Equals("A")
                                       select new ProductoDto
                                       {
                                           ProductoId = p.ProductoId,
                                           ProductoDescrip = p.ProductoDescrip,
                                           Estado = p.Estado,
                                           FechaHoraReg = p.FechaHoraReg,
                                           Precio = p.Precio,
                                           CategNombre = c.CategNombre,
                                           MarcaNombre = m.MarcaNombre,
                                           ModeloNombre = mo.ModeloDescripción
                                       }).ToListAsync();
                }
                else
                {
                    if (precio > 0)
                    {
                        resp.data = await qryPro.Where(x => x.Precio >= precio).OrderByDescending(x => x.Precio).ToListAsync();
                    }
                    else
                    {
                        resp.data = await qryPro.Where(x => x.ProductoId == productoId).ToListAsync();
                    }
                }

                resp.code = "200";
                resp.mensaje = "Correcto!";
            }
            catch (Exception ex)
            {
                resp.code = "400";
                resp.mensaje = $"Error en ProductoServices {ex.Message}";
            }

            return resp;
        }
        public async Task<Respuesta> PostProducto(Producto producto)
        {

            var resp = new Respuesta();

            try
            {
                /*
                var lst = new List<Producto>();

                if (producto.ProductoId is null || producto.ProductoId == 0)
                {
                    producto.ProductoId = _context.Productos.Max(x => x.ProductoId) + 1;
                }
                else {
                   lst = _context.Productos.Where(x => x.ProductoId == producto.ProductoId).ToList();
                }

                if (lst.Count > 0)
                {
                    resp.code = "200";
                    resp.data = producto;
                    resp.mensaje = "Registrado exitosamente";
                }
                else {
                    _context.Productos.Add(producto);
                    await _context.SaveChangesAsync();

                    resp.code = "200";
                    resp.data = producto;
                    resp.mensaje = "Registrado exitosamente";
                }
                */

                producto.ProductoId = _context.Productos.Max(x => x.ProductoId) + 1;
                producto.FechaHoraReg = DateTime.Now;

                _context.Productos.Add(producto);
                await _context.SaveChangesAsync();

                resp.code = "200";
                resp.data = producto;
                resp.mensaje = "Registrado exitosamente";

            }
            catch (Exception ex)
            {
                resp.code = "400";
                resp.mensaje = $"Se presentó un error: {ex.Message}";
            }

            return resp;
        }
        public async Task<Respuesta> PutProducto(Producto producto)
        {

            var resp = new Respuesta();

            try
            {

                var pro = new Producto();
                pro = _context.Productos.Where(x => x.ProductoId == producto.ProductoId).FirstOrDefault();

                if (pro.ProductoId == null || pro.ProductoId == 0)
                {
                    resp.code = "400";
                    resp.data = producto;
                    resp.mensaje = "No existe el producto";
                }
                else
                {

                    pro.ProductoDescrip = producto.ProductoDescrip;
                    pro.Estado = producto.Estado;
                    pro.FechaHoraReg = DateTime.Now;
                    pro.Precio = producto.Precio;
                    pro.CategId = producto.CategId;
                    pro.MarcaId = producto.MarcaId;
                    pro.ModeloId = producto.ModeloId;

                    _context.Productos.Update(pro);
                    await _context.SaveChangesAsync();

                    resp.code = "200";
                    resp.data = pro;
                    resp.mensaje = "Actualizado exitosamente";
                }

            }
            catch (Exception ex)
            {
                resp.code = "400";
                resp.mensaje = $"Se presentó un error: {ex.Message}";
            }

            return resp;
        }
        public async Task<Respuesta> PutProducto2(Producto producto, int productoId)
        {

            var resp = new Respuesta();

            try
            {

                var lst = new List<Producto>();
                lst = _context.Productos.Where(x => x.ProductoId == productoId).ToList();

                if (lst.Count == 0)
                {
                    resp.code = "400";
                    resp.data = producto;
                    resp.mensaje = "No existe el producto";
                }
                else
                {

                    lst[0].ProductoDescrip = producto.ProductoDescrip;
                    lst[0].Estado = producto.Estado;
                    lst[0].FechaHoraReg = DateTime.Now;
                    lst[0].Precio = producto.Precio;
                    lst[0].CategId = producto.CategId;
                    lst[0].MarcaId = producto.MarcaId;
                    lst[0].ModeloId = producto.ModeloId;

                    _context.Productos.Update(lst[0]);
                    await _context.SaveChangesAsync();

                    resp.code = "200";
                    resp.data = lst[0];
                    resp.mensaje = "Actualizado exitosamente";
                }

            }
            catch (Exception ex)
            {
                resp.code = "400";
                resp.mensaje = $"Se presentó un error: {ex.Message}";
            }

            return resp;
        }
    }
}
