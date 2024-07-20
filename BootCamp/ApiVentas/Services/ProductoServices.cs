using ApiVentas.DTOs;
using ApiVentas.Interfaces;
using ApiVentas.Models;
using ApiVentas.Utilitarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Linq.Expressions;
using System.Linq.Dynamic;

namespace ApiVentas.Services
{
    public class ProductoServices : IProductoServices
    {
        private BaseErpContext _context;
        private ProductoDTO dto=new ProductoDTO();
        private ControlError log = new ControlError();
        private DynamicEmpty empty= new DynamicEmpty(); 
        public ProductoServices(BaseErpContext context)
        {
            this._context = context;
        }
        public async Task<Respuesta> DeleteProducto(int id)
        {
            var result=new Respuesta();
            try
            {
                var productoDelete= await _context.Productos.FirstOrDefaultAsync(x=>x.ProdId==id);
                if (productoDelete!=null) 
                {
                    productoDelete.EstadoId = 2;
                    _context.Productos.Update(productoDelete);
                    await _context.SaveChangesAsync();
                }
                result.cod = productoDelete != null ? "000" : "111";
                result.mensaje = productoDelete != null ? "OK" : $"No se encontro registro con id: '{id}'";

            }
            catch (Exception ex)
            {
                result.cod = "999";
                result.mensaje = "Se ha presentado un exception por favor comunicarse con sistemas";
                log.LogError(this.GetType().Name, "DeleteProducto", ex.Message);
                
            }
            return result;
        }

        public async Task<Respuesta> GetProducto(string? opcion, string? data, string? data2)
        {
            var result = new Respuesta();
            Expression<Func<ProductoDTO, bool>> query =dto.DictionaryProducto(opcion, data, data2);
            try
            {
                result.cod = "000";
                result.mensaje = "OK";
                if (query != null)
                {
                    result.data = await(from p in _context.Productos
                                        join c in _context.Categoria on p.CategoriaId equals c.CategoriaId
                                        join e in _context.Empresas on p.EmpresaId equals e.EmpresaId
                                        join prove in _context.Proveedors on p.ProveedorId equals prove.ProvId
                                        join userReg in _context.Usuarios on p.UsuIdReg equals userReg.UsuId
                                        join est in _context.Estados on p.EstadoId equals est.EstadoId
                                        //join userAct in _context.Usuarios on p.UsuIdAct equals userAct.UsuId
                                        select new ProductoDTO
                                   {
                                       ProdId = p.ProdId,
                                       ProdDescripcion = p.ProdDescripcion,
                                       ProdUltPrecio = p.ProdUltPrecio,
                                       FechaHoraAct = p.FechaHoraAct,
                                       FechaHoraReg = p.FechaHoraReg,
                                       UsuIdReg = p.UsuIdReg,
                                       UsuRegDescrip = userReg.UsuNombre,
                                       UsuIdAct = p.UsuIdAct,
                                       //UsuActDescrip = userAct.UsuNombre,
                                       EstadoId = p.EstadoId,
                                       EstadoDescrip=est.EstadoDescrip,
                                       CategoriaId = p.CategoriaId,
                                       CategoriaDesrip = c.CategoriaDescrip,
                                       EmpresaId = p.EmpresaId,
                                       EmpresaDescrip = e.EmpresaNombre,
                                       ProveedorId = p.ProveedorId,
                                       ProveedorDescrip = prove.ProvNomComercial
                                   }).Where(query).ToListAsync();
                }
                if (empty.IsEmpty(result.data))
                {
                    result.cod = "111";
                    result.mensaje = data2.IsNullOrEmpty() ? $"No se encontro registros para la opcion: '{opcion}' con data: '{data}'" : $"No se encontro registros para la opcion: '{opcion}' con rango de data: '{data}' y '{data2}' ";
                }
            }
            catch (Exception ex)
            {
                result.cod = "999";
                result.mensaje = "Se ha presentado un exception por favor comunicarse con sistemas";
                log.LogError(this.GetType().Name, "GetProducto", ex.Message);

            }
            return result;
        }

        public async Task<Respuesta> PostProducto(Producto producto)
        {
            var result = new Respuesta();
            try
            {
                var id=await _context.Productos.OrderByDescending(x=>x.ProdId).Select(x=>x.ProdId).FirstOrDefaultAsync()+1;
                producto.ProdId = id;
                producto.FechaHoraReg=DateTime.Now;
                var validar = producto.UsuIdReg != null;
                if (validar)
                {
                    _context.Productos.Add(producto);   
                    await _context.SaveChangesAsync();
                }
                result.cod = validar ? "000" : "111";
                result.mensaje = validar ? "Ok" : "No se puede ingresar registro sin datos del usuario";
            }
            catch (Exception ex)
            {
                result.cod = "999";
                result.mensaje = "Se ha presentado un exception por favor comunicarse con sistemas";
                log.LogError(this.GetType().Name, "PostProducto", ex.Message);

            }
            return result;
        }

        public async Task<Respuesta> PutProducto(Producto producto)
        {
            var result = new Respuesta();
            try
            {
                var validar = await _context.Productos.AnyAsync(x => x.ProdId == producto.ProdId);
                var usuarioEdit = producto.UsuIdAct;
                if (validar && usuarioEdit!=null)
                {
                    result.cod = "000";
                    result.mensaje = "OK";
                    producto.UsuIdReg=await _context.Productos.Where(x => x.ProdId == producto.ProdId).Select(x=>x.UsuIdReg).FirstOrDefaultAsync();
                    producto.FechaHoraReg=await _context.Productos.Where(x => x.ProdId == producto.ProdId).Select(x=>x.FechaHoraReg).FirstOrDefaultAsync();
                    producto.FechaHoraAct = DateTime.Now;
                    _context.Productos.Update(producto);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    result.cod = "111";
                    result.mensaje = usuarioEdit!=null?$"No se encontro registro con id: '{producto.ProdId}'": "No se puede actualizar registro sin los datos del usuario";
                }

            }
            catch (Exception ex)
            {
                result.cod = "999";
                result.mensaje = "Se ha presentado un exception por favor comunicarse con sistemas";
                log.LogError(this.GetType().Name, "PutProducto", ex.Message);

            }
            return result;
        }
    }
}
