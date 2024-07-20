using ApiVentas.DTOs;
using ApiVentas.Interfaces;
using ApiVentas.Models;
using ApiVentas.Utilitarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Linq.Expressions;

namespace ApiVentas.Services
{
    public class BodegaServices : IBodegaServices
    {
        private BaseErpContext _context;
        private BodegaDTO dto = new BodegaDTO();
        private ControlError log = new ControlError();
        private DynamicEmpty empty = new DynamicEmpty();
        public BodegaServices(BaseErpContext context)
        {
            this._context = context;
        }
        public async Task<Respuesta> DeleteBodega(int id)
        {
            var result = new Respuesta();
            try
            {
                var bodegaDelete = await _context.Bodegas.FirstOrDefaultAsync(x => x.BodegaId == id);
                if (bodegaDelete != null)
                {
                    bodegaDelete.EstadoId = 2;
                    _context.Bodegas.Update(bodegaDelete);
                    await _context.SaveChangesAsync();
                }
                result.cod = bodegaDelete != null ? "000" : "111";
                result.mensaje = bodegaDelete != null ? "OK" : $"No se encontro registro con id: '{id}'";

            }
            catch (Exception ex)
            {
                result.cod = "999";
                result.mensaje = "Se ha presentado un exception por favor comunicarse con sistemas";
                log.LogError(this.GetType().Name, "DeleteBodega", ex.Message);

            }
            return result;
        }

        public async Task<Respuesta> GetBodega(string? opcion, string? data)
        {
            var result = new Respuesta();
            Expression<Func<BodegaDTO, bool>> query = dto.DictionaryBodega(opcion, data);
            try
            {
                if (query != null)
                {
                    result.data = await (from b in _context.Bodegas
                                         join s in _context.Sucursals on b.SucursalId equals s.SucursalId
                                         join userReg in _context.Usuarios on b.UsuIdReg equals userReg.UsuId
                                         join est in _context.Estados on b.EstadoId equals est.EstadoId
                                         //join userAct in _context.Usuarios on b.UsuIdAct equals userAct.UsuId
                                         select new BodegaDTO
                                         {
                                             BodegaId = b.BodegaId,
                                             BodegaNombre= b.BodegaNombre,
                                             BodegaDireccion= b.BodegaDireccion,
                                             BodegaTelefono= b.BodegaTelefono,
                                             SucursalId= b.SucursalId,
                                             SucursalDescrip=s.SucursalNombre,
                                             EstadoId= b.EstadoId,  
                                             EstadoDescrip=est.EstadoDescrip,
                                             FechaHoraReg=b.FechaHoraReg,
                                             FechaHoraAct=b.FechaHoraAct,   
                                             UsuIdReg=b.UsuIdReg,
                                             UsuRegDescrip=userReg.UsuNombre,
                                             UsuIdAct=b.UsuIdAct,
                                         }).Where(query).ToListAsync();
                }
                result.cod = empty.IsEmpty(result.data) ? "111" : "000";
                result.mensaje = empty.IsEmpty(result.data) ? $"No se encontro registro con opcion: '{opcion}' con data: '{data}'" : "OK";
            }
            catch (Exception ex)
            {
                result.cod = "999";
                result.mensaje = "Se ha presentado un exception por favor comunicarse con sistemas";
                log.LogError(this.GetType().Name, "GetBodega", ex.Message);

            }
            return result;
        }

        public async Task<Respuesta> PostBodega(Bodega bodega)
        {
            var result = new Respuesta();
            try
            {
                var id = await _context.Bodegas.OrderByDescending(x => x.BodegaId).Select(x => x.BodegaId).FirstOrDefaultAsync() + 1;
                bodega.BodegaId = id;
                bodega.FechaHoraReg = DateTime.Now;
                var validar = bodega.UsuIdReg != null;
                if (validar)
                {
                    _context.Bodegas.Add(bodega);
                    await _context.SaveChangesAsync();
                }
                result.cod = validar ? "000" : "111";
                result.mensaje = validar ? "Ok" : "No se puede ingresar registro sin datos del usuario";
            }
            catch (Exception ex)
            {
                result.cod = "999";
                result.mensaje = "Se ha presentado un exception por favor comunicarse con sistemas";
                log.LogError(this.GetType().Name, "PostBodega", ex.Message);

            }
            return result;
        }

        public async Task<Respuesta> PutBodega(Bodega bodega)
        {
            var result = new Respuesta();
            try
            {
                var validar = await _context.Bodegas.AnyAsync(x => x.BodegaId == bodega.BodegaId);
                var usuarioEdit = bodega.UsuIdAct;
                if (validar && usuarioEdit != null)
                {
                    result.cod = "000";
                    result.mensaje = "OK";
                    bodega.UsuIdReg = await _context.Bodegas.Where(x => x.BodegaId == bodega.BodegaId).Select(x => x.UsuIdReg).FirstOrDefaultAsync();
                    bodega.FechaHoraReg = await _context.Bodegas.Where(x => x.BodegaId == bodega.BodegaId).Select(x => x.FechaHoraReg).FirstOrDefaultAsync();
                    bodega.FechaHoraAct = DateTime.Now;
                    _context.Bodegas.Update(bodega);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    result.cod = "111";
                    result.mensaje = usuarioEdit != null ? $"No se encontro registro con id: '{bodega.BodegaId}'" : "No se puede actualizar registro sin los datos del usuario";
                }

            }
            catch (Exception ex)
            {
                result.cod = "999";
                result.mensaje = "Se ha presentado un exception por favor comunicarse con sistemas";
                log.LogError(this.GetType().Name, "PutBodega", ex.Message);

            }
            return result;
        }
    }
}
