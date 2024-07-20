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
    public class CiudadService : ICiudad
    {
        private readonly BaseErpContext _context;
        private readonly ControlError Log = new ControlError();

        public CiudadService(BaseErpContext context)
        {
            this._context = context;
        }

        public async Task<Respuesta> GetCiudad(int ciudadID, string? ciudadNombre, int? paisID)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = from ciu in _context.Ciudads
                            join pais in _context.Pais on ciu.PaisId equals pais.PaisId
                            join es in _context.Estados on ciu.EstadoId equals es.EstadoId
                            where es.EstadoId == 1
                            select new CiudadDto
                            {
                                CiudadID = ciu.CiudadId,
                                CiuNombre = ciu.CiudadNombre,
                                EstadoDesc = es.EstadoDescrip,
                                FechaHoraReg = ciu.FechaHoraReg,
                                FechaHoraAct = ciu.FechaHoraAct,
                                PaisDescrip = pais.PaisNombre
                            };

                if (ciudadID != 0 && !string.IsNullOrEmpty(ciudadNombre) && paisID.HasValue)
                {
                    respuesta.Data = await query.Where(ciu => ciu.CiudadID == ciudadID
                                                            && ciu.CiuNombre.Contains(ciudadNombre)
                                                            && ciu.PaisDescrip.Contains(paisID.ToString())).ToListAsync();
                }
                else if (ciudadID != 0 && !string.IsNullOrEmpty(ciudadNombre))
                {
                    respuesta.Data = await query.Where(ciu => ciu.CiudadID == ciudadID
                                                            && ciu.CiuNombre.Contains(ciudadNombre)).ToListAsync();
                }
                else if (ciudadID != 0 && paisID.HasValue)
                {
                    respuesta.Data = await query.Where(ciu => ciu.CiudadID == ciudadID
                                                            && ciu.PaisDescrip.Contains(paisID.ToString())).ToListAsync();
                }
                else if (!string.IsNullOrEmpty(ciudadNombre) && paisID.HasValue)
                {
                    respuesta.Data = await query.Where(ciu => ciu.CiuNombre.Contains(ciudadNombre)
                                                            && ciu.PaisDescrip.Contains(paisID.ToString())).ToListAsync();
                }
                else if (ciudadID != 0)
                {
                    respuesta.Data = await query.Where(ciu => ciu.CiudadID == ciudadID).ToListAsync();
                }
                else if (!string.IsNullOrEmpty(ciudadNombre))
                {
                    respuesta.Data = await query.Where(ciu => ciu.CiuNombre.Contains(ciudadNombre)).ToListAsync();
                }
                else if (paisID.HasValue)
                {
                    respuesta.Data = await query.Where(ciu => ciu.PaisDescrip.Contains(paisID.ToString())).ToListAsync();
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
                Log.LogErrorMetodos("CiudadServices", "GetCiudad", ex.Message);
            }

            return respuesta;
        }


        public async Task<Respuesta> PostCiudad(Ciudad ciudad)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = await _context.Ciudads.OrderByDescending(x => x.CiudadId).Select(x => x.CiudadId).FirstOrDefaultAsync();
                ciudad.CiudadId = query == 0 ? 1 : query + 1;
                ciudad.FechaHoraReg = DateTime.Now;

                _context.Ciudads.Add(ciudad);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se insertó correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("CiudadService", "PostCiudad", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PutCiudad(Ciudad ciudad)
        {
            var respuesta = new Respuesta();
            try
            {
                bool existingCiudad = await _context.Ciudads.AnyAsync(x => x.CiudadId == ciudad.CiudadId);
                if (existingCiudad)
                {
                    ciudad.FechaHoraAct = DateTime.Now;

                    _context.Ciudads.Update(ciudad);
                    await _context.SaveChangesAsync();

                    respuesta.Cod = "000";
                    respuesta.Mensaje = "Se actualizó correctamente";
                }
                else
                {
                    respuesta.Cod = "999";
                    respuesta.Mensaje = "La ciudad no existe";
                }
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("CiudadService", "PutCiudad", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> DeleteCiudad(Ciudad ciudad)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                bool existingCiudad = await _context.Ciudads.AnyAsync(x => x.CiudadId == ciudad.CiudadId);
                if (existingCiudad)
                {
                    ciudad.FechaHoraAct = DateTime.Now;

                    ciudad.EstadoId = 2;
                    _context.Ciudads.Update(ciudad);
                    await _context.SaveChangesAsync();

                    respuesta.Cod = "000";
                    respuesta.Mensaje = "Se ha eliminado correctamente";
                }
                else
                {
                    respuesta.Cod = "999";
                    respuesta.Mensaje = "La ciudad no existe";
                }
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = "Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("CiudadService", "DeleteCiudad", ex.Message);
            }
            return respuesta;
        }
    }
}
