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
    public class ModuloServices : IModulo
    {
        public readonly BaseErpContext _context;
        public ControlError err = new ControlError();
        public string clase = "ModuloServices";

        public ModuloServices(BaseErpContext context) { _context = context; }
        public async Task<Respuesta> getListaModulo(int ModuloId, string? nombreModulo)
        {
            var resp = new Respuesta();
            var metodo = "getListaModulo";

            var qryModulo = _context.Modulos;
            var qryUsu = _context.Usuarios;

            try
            {
                IQueryable<ModuloDto> q = (from p in qryModulo
                                        select new ModuloDto
                                        {
                                            ModuloId = p.ModuloId,
                                            ModuloDescripcion = p.ModuloDescripcion,
                                            Estado = p.Estado,
                                            FechaHoraReg = p.FechaHoraReg,
                                            FechaHoraAct = p.FechaHoraAct,
                                            UsuReg = (from u in qryUsu where p.UsuIdReg == u.UsuId select u.UsuNombre).FirstOrDefault().ToString(),
                                            UsuAct = (from u in qryUsu where p.UsuIdAct == u.UsuId select u.UsuNombre).FirstOrDefault().ToString()
                                        }).AsQueryable();

                if (ModuloId == 0 && (nombreModulo == null || nombreModulo == ""))
                {
                    resp.code = "200";
                    resp.data = await q.Where(x => x.Estado == 1).ToListAsync();
                    resp.mensaje = "OK";
                }
                else if (ModuloId > 0 && (nombreModulo == null || nombreModulo == ""))
                {
                    resp.code = "200";
                    resp.data = await q.Where(x => x.Estado == 1 && x.ModuloId.Equals(ModuloId)).ToListAsync();
                    resp.mensaje = "OK";
                }
                else if (ModuloId == 0 && (nombreModulo != null || nombreModulo != ""))
                {
                    resp.code = "200";
                    resp.data = await q.Where(x => x.Estado == 1 && x.ModuloDescripcion.Equals(nombreModulo)).ToListAsync();
                    resp.mensaje = "OK";
                }
                else if (ModuloId > 0 && nombreModulo != null && nombreModulo != "")
                {
                    resp.code = "200";
                    resp.data = await q.Where(x => x.Estado == 1 && x.ModuloId.Equals(ModuloId) && x.ModuloDescripcion.Equals(nombreModulo)).ToListAsync();
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
        public async Task<Respuesta> postModulo(Modulo Modulo)
        {

            var resp = new Respuesta();
            var qry = _context.Modulos;
            var metodo = "postModulo";

            try
            {
                Modulo.ModuloId = qry.Max(x => x.ModuloId) + 1;
                Modulo.FechaHoraReg = DateTime.Now;

                qry.Add(Modulo);
                await _context.SaveChangesAsync();

                resp.code = "200";
                resp.data = Modulo;
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
        public async Task<Respuesta> putModulo(Modulo Modulo)
        {

            var resp = new Respuesta();
            var mod = new Modulo();
            var qry = _context.Modulos;
            var metodo = "putModulo";

            try
            {
                mod = qry.Where(x => x.ModuloId == Modulo.ModuloId).FirstOrDefault();

                if (mod.ModuloId == null || mod.ModuloId == 0)
                {
                    resp.code = "400";
                    resp.data = Modulo;
                    resp.mensaje = "No existe el Modulo";
                }
                else
                {

                    mod.ModuloDescripcion = Modulo.ModuloDescripcion;
                    mod.ModuloId = Modulo.ModuloId;
                    mod.FechaHoraReg = DateTime.Now;
                    mod.Estado = Modulo.Estado;

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
        public async Task<Respuesta> deleteModulo(int ModuloId)
        {

            var resp = new Respuesta();
            var mod = new Modulo();
            var qry = _context.Modulos;
            var metodo = "deleteModulo";

            try
            {
                mod = qry.Where(x => x.ModuloId == ModuloId && x.Estado == 1).FirstOrDefault();

                if (mod.ModuloId == null || mod.ModuloId == 0)
                {
                    resp.code = "400";
                    resp.data = ModuloId;
                    resp.mensaje = "No existe o ya fue eliminada la Modulo";
                }
                else
                {

                    mod.FechaHoraReg = DateTime.Now;
                    mod.Estado = 0;

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
