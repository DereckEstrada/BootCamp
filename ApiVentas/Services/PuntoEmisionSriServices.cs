﻿using ApiVentas.DTOs;
using ApiVentas.Interfaces;
using ApiVentas.Models;
using ApiVentas.Utilitarios;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ApiVentas.Services
{
    public class PuntoEmisionSriServices: IPuntoEmisionSriServices
    {
        private BaseErpContext _context;
        private PuntoEmisionSriDTO dto = new PuntoEmisionSriDTO();
        private ControlError log = new ControlError();
        private DynamicEmpty empty = new DynamicEmpty();
        public PuntoEmisionSriServices(BaseErpContext context)
        {
            this._context = context;
        }
        public async Task<Respuesta> DeletePuntoEmisionSri(int id)
        {
            var result = new Respuesta();
            try
            {
                var emisionSriDelete = await _context.PuntoEmisionSris.FirstOrDefaultAsync(x => x.PuntoEmisionId== id);
                if (emisionSriDelete != null)
                {
                    emisionSriDelete.EstadoId = 2;
                    _context.PuntoEmisionSris.Update(emisionSriDelete);
                    await _context.SaveChangesAsync();
                }
                result.Cod = emisionSriDelete!= null ? "000" : "111";
                result.Mensaje = emisionSriDelete!= null ? "OK" : $"No se encontro registro con id: '{id}'";

            }
            catch (Exception ex)
            {
                result.Cod = "999";
                result.Mensaje = "Se ha presentado un exception por favor comunicarse con sistemas";
                log.LogErrorMetodos(this.GetType().Name, "DeletePuntoEmisionSri", ex.Message);

            }
            return result;
        }

        public async Task<Respuesta> GetPuntoEmisionSri(string? opcion, string? Data)
        {
            var result = new Respuesta();
            Expression<Func<PuntoEmisionSriDTO, bool>> query = dto.DictionaryPuntoSri(opcion, Data);
            try
            {
                if (query != null)
                {
                    result.Data = await (from emision in _context.PuntoEmisionSris
                                         join e in _context.Empresas on emision.EmpresaId equals e.EmpresaId   
                                         join s in _context.Sucursals on emision.SucursalId equals s.SucursalId
                                         join userReg in _context.Usuarios on emision.UsuIdReg equals userReg.UsuId
                                         join est in _context.Estados on emision.EstadoId equals est.EstadoId
                                         //join userAct in _context.Usuarios on emision.UsuIdAct equals userAct.UsuId
                                         select new PuntoEmisionSriDTO
                                         {
                                             PuntoEmisionId= emision.PuntoEmisionId,
                                             PuntoEmision=emision.PuntoEmision,
                                             EmpresaId=emision.EmpresaId,
                                             EmpresaDescrip=e.EmpresaNombre,
                                             SucursalId=emision.SucursalId,
                                             SucursalDescrip=s.SucursalNombre,
                                             CodEstablecimientoSri=emision.CodEstablecimientoSri,
                                             UltSecuencia=emision.UltSecuencia,
                                             EstadoId=emision.EstadoId,
                                             EstadoDescrip=est.EstadoDescrip,
                                             FechaHoraReg=emision.FechaHoraReg, 
                                             FechaHoraAct=emision.FechaHoraAct,
                                             UsuIdReg=emision.UsuIdReg,
                                             UsuRegDescrip=userReg.UsuNombre,
                                             UsuIdAct=emision.UsuIdAct,
                                             //UsuActDescrip=userAct.UsuNombre
                                         }).Where(query).ToListAsync();
                }
                result.Cod = empty.IsEmpty(result.Data) ? "111" : "000";
                result.Mensaje = empty.IsEmpty(result.Data) ? $"No se encontro registro con opcion: '{opcion}' con Data: '{Data}'" : "OK";
            }
            catch (Exception ex)
            {
                result.Cod = "999";
                result.Mensaje = "Se ha presentado un exception por favor comunicarse con sistemas";
                log.LogErrorMetodos(this.GetType().Name, "GetPuntoEmisionSri", ex.Message);

            }
            return result;
        }

        public async Task<Respuesta> PostPuntoEmisionSri(PuntoEmisionSri emisionSri)
        {
            var result = new Respuesta();
            try
            {
                var id = await _context.PuntoEmisionSris.OrderByDescending(x => x.PuntoEmisionId).Select(x => x.PuntoEmisionId).FirstOrDefaultAsync() + 1;
                emisionSri.PuntoEmisionId= id;
                emisionSri.FechaHoraReg = DateTime.Now;
                var validar = emisionSri.UsuIdReg != null;
                if (validar)
                {
                    _context.PuntoEmisionSris.Add(emisionSri);
                    await _context.SaveChangesAsync();
                }
                result.Cod = validar ? "000" : "111";
                result.Mensaje = validar ? "Ok" : "No se puede ingresar registro sin datos del usuario";
            }
            catch (Exception ex)
            {
                result.Cod = "999";
                result.Mensaje = "Se ha presentado un exception por favor comunicarse con sistemas";
                log.LogErrorMetodos(this.GetType().Name, "PostPuntoEmisionSri", ex.Message);

            }
            return result;
        }

        public async Task<Respuesta> PutPuntoEmisionSri(PuntoEmisionSri emisionSri)
        {
            var result = new Respuesta();
            try
            {
                var validar = await _context.PuntoEmisionSris.AnyAsync(x => x.PuntoEmisionId== emisionSri.PuntoEmisionId);
                var usuarioEdit = emisionSri.UsuIdAct;
                if (validar && usuarioEdit != null)
                {
                    result.Cod = "000";
                    result.Mensaje = "OK";
                    emisionSri.UsuIdReg = await _context.PuntoEmisionSris.Where(x => x.PuntoEmisionId== emisionSri.PuntoEmisionId).Select(x => x.UsuIdReg).FirstOrDefaultAsync();
                    emisionSri.FechaHoraReg = await _context.PuntoEmisionSris.Where(x => x.PuntoEmisionId == emisionSri.PuntoEmisionId).Select(x => x.FechaHoraReg).FirstOrDefaultAsync();
                    emisionSri.FechaHoraAct = DateTime.Now;
                    _context.PuntoEmisionSris.Update(emisionSri);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    result.Cod = "111";
                    result.Mensaje = usuarioEdit != null ? $"No se encontro registro con id: '{emisionSri.PuntoEmisionId}'" : "No se puede actualizar registro sin los datos del usuario";
                }
            }
            catch (Exception ex)
            {
                result.Cod = "999";
                result.Mensaje = "Se ha presentado un exception por favor comunicarse con sistemas";
                log.LogErrorMetodos(this.GetType().Name, "PutPuntoEmisionSri", ex.Message);
            }
            return result;
        }
    }
}
