using ApiVentas.DTOs;
using ApiVentas.Interfaces;
using ApiVentas.Models;
using ApiVentas.Utilitarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Linq.Expressions;
using System.Threading.Tasks.Dataflow;

namespace ApiVentas.Services
{
    public class ProveedorServices: IProveedorServices
    {
        private BaseErpContext _context;
        private ProveedorDTO dto = new ProveedorDTO();
        private ControlError log = new ControlError();
        private DynamicEmpty empty = new DynamicEmpty();
        public ProveedorServices(BaseErpContext context)
        {
            this._context = context;
        }
        public async Task<Respuesta> DeleteProveedor(int id)
        {
            var result = new Respuesta();
            try
            {
                var proveedorDelete = await _context.Proveedors.FirstOrDefaultAsync(x => x.ProvId== id);
                if (proveedorDelete != null)
                {
                    proveedorDelete.EstadoId = 2;
                    _context.Proveedors.Update(proveedorDelete);
                    await _context.SaveChangesAsync();
                }
                result.cod = proveedorDelete != null ? "000" : "111";
                result.mensaje = proveedorDelete != null ? "OK" : $"No se encontro registro con id: '{id}'";

            }
            catch (Exception ex)
            {
                result.cod = "999";
                result.mensaje = "Se ha presentado un exception por favor comunicarse con sistemas";
                log.LogError(this.GetType().Name, "DeleteProveedor", ex.Message);

            }
            return result;
        }

        public async Task<Respuesta> GetProveedor(string? opcion, string? data)
        {
            var result = new Respuesta();
            Expression<Func<ProveedorDTO, bool>> query = dto.DictionaryProveedor(opcion, data);
            try
            {
                if (query != null)
                {
                    result.data = await (from prove in _context.Proveedors
                                         join c in _context.Ciudads on prove.CiudadId equals c.CiudadId
                                         join userReg in _context.Usuarios on prove.UsuIdReg equals userReg.UsuId
                                         join est in _context.Estados on prove.EstadoId equals est.EstadoId
                                         //join userAct in _context.Usuarios on prove.UsuIdAct equals userAct.UsuId
                                         select new ProveedorDTO
                                         {
                                             ProvId = prove.ProvId,
                                             ProvRuc=prove.ProvRuc,
                                             ProvNomComercial=prove.ProvNomComercial,
                                             ProvRazon=prove.ProvRazon,
                                             ProvDireccion=prove.ProvDireccion,
                                             ProvTelefono=prove.ProvTelefono,
                                             CiudadId=prove.CiudadId,
                                             CiudadDescrip=c.CiudadNombre,
                                             EstadoId=prove.EstadoId,
                                             EstadoDescrip=est.EstadoDescrip,
                                             FechaHoraReg=prove.FechaHoraReg,
                                             FechaHoraAct=prove.FechaHoraAct,
                                             UsuIdReg=prove.UsuIdReg,
                                             UsuRegDescrip=userReg.UsuNombre,
                                             UsuIdAct=prove.UsuIdAct,   
                                             //UsuActDescrip=userAct.UsuNombre   
                                         }).Where(query).ToListAsync();
                }
                result.cod = empty.IsEmpty(result.data) ? "111" : "000";
                result.mensaje = empty.IsEmpty(result.data) ? $"No se encontro registro con opcion: '{opcion}' con data: '{data}'" : "OK";
            }
            catch (Exception ex)
            {
                result.cod = "999";
                result.mensaje = "Se ha presentado un exception por favor comunicarse con sistemas";
                log.LogError(this.GetType().Name, "GetProveedor", ex.Message);

            }
            return result;
        }

        public async Task<Respuesta> PostProveedor(Proveedor proveedor)
        {
            var result = new Respuesta();
            try
            {
                var id = await _context.Proveedors.OrderByDescending(x => x.ProvId).Select(x => x.ProvId).FirstOrDefaultAsync() + 1;
                proveedor.ProvId= id;
                proveedor.FechaHoraReg = DateTime.Now;
                var validar = proveedor.UsuIdReg != null;
                if (validar)
                {
                    _context.Proveedors.Add(proveedor);
                    await _context.SaveChangesAsync();
                }
                result.cod = validar ? "000" : "111";
                result.mensaje = validar ? "Ok" : "No se puede ingresar registro sin datos del usuario";
            }
            catch (Exception ex)
            {
                result.cod = "999";
                result.mensaje = "Se ha presentado un exception por favor comunicarse con sistemas";
                log.LogError(this.GetType().Name, "PostProveedor", ex.Message);

            }
            return result;
        }

        public async Task<Respuesta> PutProveedor(Proveedor proveedor)
        {
            var result = new Respuesta();
            try
            {
                var validar = await _context.Proveedors.AnyAsync(x => x.ProvId== proveedor.ProvId);
                var usuarioEdit = proveedor.UsuIdAct;
                if (validar && usuarioEdit != null)
                {
                    result.cod = "000";
                    result.mensaje = "OK";
                    proveedor.UsuIdReg = await _context.Proveedors.Where(x => x.ProvId== proveedor.ProvId).Select(x => x.UsuIdReg).FirstOrDefaultAsync();
                    proveedor.FechaHoraReg = await _context.Proveedors.Where(x => x.ProvId == proveedor.ProvId).Select(x => x.FechaHoraReg).FirstOrDefaultAsync();
                    proveedor.FechaHoraAct = DateTime.Now;
                    _context.Proveedors.Update(proveedor);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    result.cod = "111";
                    result.mensaje = usuarioEdit != null ? $"No se encontro registro con id: '{proveedor.ProvId}'" : "No se puede actualizar registro sin los datos del usuario";
                }
            }
            catch (Exception ex)
            {
                result.cod = "999";
                result.mensaje = "Se ha presentado un exception por favor comunicarse con sistemas";
                log.LogError(this.GetType().Name, "PutProveedor", ex.Message);
            }
            return result;
        }
    }
}
