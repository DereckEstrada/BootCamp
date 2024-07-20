using ApiVentas.DTOs;
using ApiVentas.Interfaces;
using ApiVentas.Models;
using ApiVentas.Utilitarios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace ApiVentas.Services
{
    public class BodegaService : IBodega
    {
        private readonly BaseErpContext _context;
        private readonly ControlError Log = new ControlError();

        public BodegaService(BaseErpContext context)
        {
            this._context = context;
        }

        public async Task<Respuesta> GetBodega(int bodegaID, string? bodegaNombre, string? bodegaTelefono)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = (from b in _context.Bodegas
                             join suc in _context.Sucursals on b.SucursalId equals suc.SucursalId
                             join es in _context.Estados on b.EstadoId equals es.EstadoId
                             where es.EstadoId == 1
                             select new BodegaDto
                             {
                                 BodegaID = b.BodegaId,
                                 BodNombre = b.BodegaNombre,
                                 BodDir = b.BodegaDireccion,
                                 BodTel = b.BodegaTelefono,
                                 EstadoDesc = es.EstadoDescrip,
                                 FecHoraReg = b.FechaHoraReg,
                                 FecHoraAct = b.FechaHoraAct,
                                 SucursalDescrip = suc.SucursalNombre 
                             });

                if (bodegaID != 0 && !string.IsNullOrEmpty(bodegaNombre) && !string.IsNullOrEmpty(bodegaTelefono))
                {
                    respuesta.Data = await query.Where(b => b.BodegaID == bodegaID && b.BodNombre.Contains(bodegaNombre) && b.BodTel.Contains(bodegaTelefono)).ToListAsync();
                }
                else if (bodegaID != 0 && !string.IsNullOrEmpty(bodegaNombre))
                {
                    respuesta.Data = await query.Where(b => b.BodegaID == bodegaID && b.BodNombre.Contains(bodegaNombre)).ToListAsync();
                }
                else if (bodegaID != 0 && !string.IsNullOrEmpty(bodegaTelefono))
                {
                    respuesta.Data = await query.Where(b => b.BodegaID == bodegaID && b.BodTel.Contains(bodegaTelefono)).ToListAsync();
                }
                else if (!string.IsNullOrEmpty(bodegaNombre) && !string.IsNullOrEmpty(bodegaTelefono))
                {
                    respuesta.Data = await query.Where(b => b.BodNombre.Contains(bodegaNombre) && b.BodTel.Contains(bodegaTelefono)).ToListAsync();
                }
                else if (bodegaID != 0)
                {
                    respuesta.Data = await query.Where(b => b.BodegaID == bodegaID).ToListAsync();
                }
                else if (!string.IsNullOrEmpty(bodegaNombre))
                {
                    respuesta.Data = await query.Where(b => b.BodNombre.Contains(bodegaNombre)).ToListAsync();
                }
                else if (!string.IsNullOrEmpty(bodegaTelefono))
                {
                    respuesta.Data = await query.Where(b => b.BodTel.Contains(bodegaTelefono)).ToListAsync();
                }
                else
                {
                    respuesta.Data = await query.ToListAsync();
                }

                respuesta.Cod = "000";
                respuesta.Mensaje = "OK";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("BodegaService", "GetBodega", ex.Message);
            }

            return respuesta;
        }



        public async Task<Respuesta> PostBodega(Bodega bodega)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = await _context.Bodegas.OrderByDescending(x => x.BodegaId).Select(x => x.BodegaId).FirstOrDefaultAsync();
                bodega.BodegaId = query == 0 ? 1 : query + 1;
                bodega.FechaHoraReg = DateTime.Now;

                _context.Bodegas.Add(bodega);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se insertó correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("BodegaService", "PostBodega", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PutBodega(Bodega bodega)
        {
            var respuesta = new Respuesta();
            try
            {
                bool existingBodega = await _context.Bodegas.AnyAsync(x => x.BodegaId == bodega.BodegaId);
                if (existingBodega)
                {
                    bodega.FechaHoraAct = DateTime.Now;

                    _context.Bodegas.Update(bodega);
                    await _context.SaveChangesAsync();

                    respuesta.Cod = "000";
                    respuesta.Mensaje = "Se actualizó correctamente";
                }
                else
                {
                    respuesta.Cod = "999";
                    respuesta.Mensaje = "La bodega no existe";
                }
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("BodegaService", "PutBodega", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> DeleteBodega(Bodega bodega)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                bool existingBodega = await _context.Bodegas.AnyAsync(x => x.BodegaId == bodega.BodegaId);
                if (existingBodega)
                {
                    bodega.FechaHoraAct = DateTime.Now;

                    bodega.EstadoId = 2;
                    _context.Bodegas.Update(bodega);
                    await _context.SaveChangesAsync();

                    respuesta.Cod = "000";
                    respuesta.Mensaje = "Se ha eliminado correctamente";
                }
                else
                {
                    respuesta.Cod = "999";
                    respuesta.Mensaje = "La bodega no existe";
                }
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = "Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("BodegaService", "DeleteBodega", ex.Message);
            }
            return respuesta;
        }
    }
}
