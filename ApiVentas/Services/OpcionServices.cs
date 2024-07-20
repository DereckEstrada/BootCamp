using ApiVentas.Interfaces;
using ApiVentas.Models;
using ApiVentas.Utilitarios;
using ApiVentas.Interfaces;
using ApiVentas.Models;
using ApiVentas.Utilitarios;
using Microsoft.EntityFrameworkCore;
using ApiVentas.DTOs;

namespace ejemploEntity.Services
{
    public class OpcionServices : IOpcion
    {
        public readonly BaseErpContext _context;
        public ControlError err = new ControlError();
        public string clase = "OpcionServices";

        public OpcionServices(BaseErpContext context) { _context = context; }
        public async Task<Respuesta> getListaOpcion(int OpcionId, string? nombreOpcion)
        {
            var resp = new Respuesta();
            var metodo = "getListaOpcion";

            var qryOpcion = _context.Opcions;
            var qryUsu = _context.Usuarios;
            var qryModulo = _context.Modulos;

            try
            {
                IQueryable<OpcionDto> q = (from o in qryOpcion
                                           join m in qryModulo on o.ModuloId equals m.ModuloId
                                           select new OpcionDto
                                           {
                                               OpcionId = o.OpcionId,
                                               OpcionDescripcion = o.OpcionDescripcion,
                                               Estado = o.EstadoId,
                                               FechaHoraReg = o.FechaHoraReg,
                                               FechaHoraAct = o.FechaHoraAct,
                                               UsuReg = (from u in qryUsu where o.UsuIdReg == u.UsuId select u.UsuNombre).FirstOrDefault().ToString(),
                                               UsuAct = (from u in qryUsu where o.UsuIdAct == u.UsuId select u.UsuNombre).FirstOrDefault().ToString(),
                                               ModuloDescripcion = m.ModuloDescripcion
                                           }).AsQueryable();

                if (OpcionId == 0 && (nombreOpcion == null || nombreOpcion == ""))
                {
                    resp.code = "200";
                    resp.data = await q.Where(x => x.Estado == 1).ToListAsync();
                    resp.mensaje = "OK";
                }
                else if (OpcionId > 0 && (nombreOpcion == null || nombreOpcion == ""))
                {
                    resp.code = "200";
                    resp.data = await q.Where(x => x.Estado == 1 && x.OpcionId.Equals(OpcionId)).ToListAsync();
                    resp.mensaje = "OK";
                }
                else if (OpcionId == 0 && (nombreOpcion != null || nombreOpcion != ""))
                {
                    resp.code = "200";
                    resp.data = await q.Where(x => x.Estado == 1 && x.OpcionDescripcion.Equals(nombreOpcion)).ToListAsync();
                    resp.mensaje = "OK";
                }
                else if (OpcionId > 0 && nombreOpcion != null && nombreOpcion != "")
                {
                    resp.code = "200";
                    resp.data = await q.Where(x => x.Estado == 1 && x.OpcionId.Equals(OpcionId) && x.OpcionDescripcion.Equals(nombreOpcion)).ToListAsync();
                    resp.mensaje = "OK";
                }
            }
            catch (Exception ex)
            {
                resp.code = "400";
                resp.mensaje = $"Error en {clase}: {ex.Message}";
                err.LogErrorMetodos(clase, metodo, ex.Message);
            }

            return resp;
        }
        public async Task<Respuesta> postOpcion(Opcion Opcion)
        {

            var resp = new Respuesta();
            var qry = _context.Opcions;
            var metodo = "postOpcion";

            try
            {
                Opcion.OpcionId = qry.Max(x => x.OpcionId) + 1;
                Opcion.FechaHoraReg = DateTime.Now;

                qry.Add(Opcion);
                await _context.SaveChangesAsync();

                resp.code = "200";
                resp.data = Opcion;
                resp.mensaje = "Registrado exitosamente";

            }
            catch (Exception ex)
            {
                resp.code = "400";
                resp.mensaje = $"Error en {clase}: {ex.Message}";
                err.LogErrorMetodos(clase, metodo, ex.Message);
            }

            return resp;
        }
        public async Task<Respuesta> putOpcion(Opcion Opcion)
        {

            var resp = new Respuesta();
            var mod = new Opcion();
            var qry = _context.Opcions;
            var metodo = "putOpcion";

            try
            {
                mod = qry.Where(x => x.OpcionId == Opcion.OpcionId).FirstOrDefault();

                if (mod.OpcionId == null || mod.OpcionId == 0)
                {
                    resp.code = "400";
                    resp.data = Opcion;
                    resp.mensaje = "No existe el Opcion";
                }
                else
                {

                    mod.OpcionDescripcion = Opcion.OpcionDescripcion;
                    mod.OpcionId = Opcion.OpcionId;
                    mod.FechaHoraReg = DateTime.Now;
                    mod.Estado = Opcion.Estado;

                    qry.Update(mod);
                    await _context.SaveChangesAsync();

                    resp.code = "200";
                    resp.data = mod;
                    resp.mensaje = "Actualizado exitosamente";
                }

            }
            catch (Exception ex)
            {
                resp.code = "400";
                resp.mensaje = $"Error en {clase}: {ex.Message}";
                err.LogErrorMetodos(clase, metodo, ex.Message);
            }

            return resp;
        }
        public async Task<Respuesta> deleteOpcion(int OpcionId)
        {

            var resp = new Respuesta();
            var mod = new Opcion();
            var qry = _context.Opcions;
            var metodo = "deleteOpcion";

            try
            {
                mod = qry.Where(x => x.OpcionId == OpcionId && x.EstadoId == 1).FirstOrDefault();

                if (mod.OpcionId == null || mod.OpcionId == 0)
                {
                    resp.code = "400";
                    resp.data = OpcionId;
                    resp.mensaje = "No existe o ya fue eliminada la Opcion";
                }
                else
                {

                    mod.FechaHoraReg = DateTime.Now;
                    mod.EstadoId = 0;

                    qry.Update(mod);
                    await _context.SaveChangesAsync();

                    resp.code = "200";
                    resp.data = mod;
                    resp.mensaje = "Eliminado exitosamente";
                }

            }
            catch (Exception ex)
            {
                resp.code = "400";
                resp.mensaje = $"Error en {clase}: {ex.Message}";
                err.LogErrorMetodos(clase, metodo, ex.Message);
            }

            return resp;
        }
    }
}
