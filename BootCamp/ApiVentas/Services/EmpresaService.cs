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
    public class EmpresaService : IEmpresa
    {
        private readonly BaseErpContext _context;
        private readonly ControlError Log = new ControlError();

        public EmpresaService(BaseErpContext context)
        {
            this._context = context;
        }

        public async Task<Respuesta> GetEmpresa(int empresaID, string? empresaNombre, string? ruc, int? ciudadID)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = from emp in _context.Empresas
                            join ciu in _context.Ciudads on emp.CiudadId equals ciu.CiudadId
                            join es in _context.Estados on emp.EstadoId equals es.EstadoId
                            where es.EstadoId == 1
                            select new EmpresaDto
                            {
                                EmpID = emp.EmpresaId,
                                EmpRuc = emp.EmpresaRuc,
                                EmpNombre = emp.EmpresaNombre,
                                EmpRazon = emp.EmpresaRazon,
                                EmpDirMatriz = emp.EmpresaDireccionMatriz,
                                EmpTelMatriz = emp.EmpresaTelefonoMatriz,
                                CiudadDescrip = ciu.CiudadNombre,
                                EstadoDesc = es.EstadoDescrip,
                                FecHoraReg = emp.FechaHoraReg,
                                FecHoraAct = emp.FechaHoraAct
                            };

                if (empresaID != 0 && !string.IsNullOrEmpty(empresaNombre) && !string.IsNullOrEmpty(ruc) && ciudadID.HasValue)
                {
                    respuesta.Data = await query.Where(emp => emp.EmpID == empresaID
                                                            && emp.EmpNombre.Contains(empresaNombre)
                                                            && emp.EmpRuc.Contains(ruc)
                                                            && emp.CiudadDescrip.Contains(ciudadID.ToString())).ToListAsync();
                }
                else if (empresaID != 0 && !string.IsNullOrEmpty(empresaNombre) && !string.IsNullOrEmpty(ruc))
                {
                    respuesta.Data = await query.Where(emp => emp.EmpID == empresaID
                                                            && emp.EmpNombre.Contains(empresaNombre)
                                                            && emp.EmpRuc.Contains(ruc)).ToListAsync();
                }
                else if (empresaID != 0 && ciudadID.HasValue)
                {
                    respuesta.Data = await query.Where(emp => emp.EmpID == empresaID
                                                            && emp.CiudadDescrip.Contains(ciudadID.ToString())).ToListAsync();
                }
                else if (!string.IsNullOrEmpty(empresaNombre) && ciudadID.HasValue)
                {
                    respuesta.Data = await query.Where(emp => emp.EmpNombre.Contains(empresaNombre)
                                                            && emp.CiudadDescrip.Contains(ciudadID.ToString())).ToListAsync();
                }
                else if (empresaID != 0)
                {
                    respuesta.Data = await query.Where(emp => emp.EmpID == empresaID).ToListAsync();
                }
                else if (!string.IsNullOrEmpty(empresaNombre))
                {
                    respuesta.Data = await query.Where(emp => emp.EmpNombre.Contains(empresaNombre)).ToListAsync();
                }
                else if (!string.IsNullOrEmpty(ruc))
                {
                    respuesta.Data = await query.Where(emp => emp.EmpRuc.Contains(ruc)).ToListAsync();
                }
                else if (ciudadID.HasValue)
                {
                    respuesta.Data = await query.Where(emp => emp.CiudadDescrip.Contains(ciudadID.ToString())).ToListAsync();
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
                respuesta.Mensaje = "Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("EmpresaServices", "GetEmpresa", ex.Message);
            }

            return respuesta;
        }



        public async Task<Respuesta> PostEmpresa(Empresa empresa)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = await _context.Empresas.OrderByDescending(x => x.EmpresaId).Select(x => x.EmpresaId).FirstOrDefaultAsync();
                empresa.EmpresaId = query == 0 ? 1 : query + 1;
                empresa.FechaHoraReg = DateTime.Now;

                _context.Empresas.Add(empresa);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se insertó correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("EmpresaService", "PostEmpresa", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PutEmpresa(Empresa empresa)
        {
            var respuesta = new Respuesta();
            try
            {
                bool existingEmpresa = await _context.Empresas.AnyAsync(x => x.EmpresaId == empresa.EmpresaId);
                if (existingEmpresa)
                {
                    empresa.FechaHoraAct = DateTime.Now;

                    _context.Empresas.Update(empresa);
                    await _context.SaveChangesAsync();

                    respuesta.Cod = "000";
                    respuesta.Mensaje = "Se actualizó correctamente";
                }
                else
                {
                    respuesta.Cod = "999";
                    respuesta.Mensaje = "La empresa no existe";
                }
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("EmpresaService", "PutEmpresa", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> DeleteEmpresa(Empresa empresa)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                bool existingEmpresa = await _context.Empresas.AnyAsync(x => x.EmpresaId == empresa.EmpresaId);
                if (existingEmpresa)
                {
                    empresa.FechaHoraAct = DateTime.Now;

                    empresa.EstadoId = 2;
                    _context.Empresas.Update(empresa);
                    await _context.SaveChangesAsync();

                    respuesta.Cod = "000";
                    respuesta.Mensaje = "Se ha eliminado correctamente";
                }
                else
                {
                    respuesta.Cod = "999";
                    respuesta.Mensaje = "La empresa no existe";
                }
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = "Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("EmpresaService", "DeleteEmpresa", ex.Message);
            }
            return respuesta;
        }
    }
}
