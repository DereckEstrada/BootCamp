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
    public class FormaPagoService : IFormaPago
    {
        private readonly BaseErpContext _context;
        private readonly ControlError Log = new ControlError();

        public FormaPagoService(BaseErpContext context)
        {
            this._context = context;
        }

        public async Task<Respuesta> GetFormaPago(int fpagoID, string? fpagoDescripcion)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = from fp in _context.FormaPagos
                            join es in _context.Estados on fp.EstadoId equals es.EstadoId
                            where es.EstadoId == 1
                            select new FormaPagoDto
                            {
                                FpagoID = fp.FpagoId,
                                FpagoDescrip = fp.FpagoDescripcion,
                                EstadoDesc = es.EstadoDescrip,
                                FecHoraReg = fp.FechaHoraReg,
                                FecHoraAct = fp.FechaHoraAct
                            };

                if (fpagoID != 0 && !string.IsNullOrEmpty(fpagoDescripcion))
                {
                    respuesta.Data = await query.Where(fp => fp.FpagoID == fpagoID
                                                            && fp.FpagoDescrip.Contains(fpagoDescripcion)).ToListAsync();
                }
                else if (fpagoID != 0)
                {
                    respuesta.Data = await query.Where(fp => fp.FpagoID == fpagoID).ToListAsync();
                }
                else if (!string.IsNullOrEmpty(fpagoDescripcion))
                {
                    respuesta.Data = await query.Where(fp => fp.FpagoDescrip.Contains(fpagoDescripcion)).ToListAsync();
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
                Log.LogErrorMetodos("FormaPagoServices", "GetFormaPago", ex.Message);
            }

            return respuesta;
        }


        public async Task<Respuesta> PostFormaPago(FormaPago formaPago)
        {
            var respuesta = new Respuesta();
            try
            {
                formaPago.FechaHoraReg = DateTime.Now;

                _context.FormaPagos.Add(formaPago);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se insertó correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("FormaPagoService", "PostFormaPago", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PutFormaPago(FormaPago formaPago)
        {
            var respuesta = new Respuesta();
            try
            {
                bool existingFormaPago = await _context.FormaPagos.AnyAsync(x => x.FpagoId == formaPago.FpagoId);
                if (existingFormaPago)
                {
                   formaPago.FechaHoraAct = DateTime.Now;

                    _context.FormaPagos.Update(formaPago);
                    await _context.SaveChangesAsync();

                    respuesta.Cod = "000";
                    respuesta.Mensaje = "Se actualizó correctamente";
                }
                else
                {
                    respuesta.Cod = "999";
                    respuesta.Mensaje = "La forma de pago no existe";
                }
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("FormaPagoService", "PutFormaPago", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> DeleteFormaPago(FormaPago formaPago)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                bool existingFormaPago = await _context.FormaPagos.AnyAsync(x => x.FpagoId == formaPago.FpagoId);
                if (existingFormaPago)
                {
                    var fechaActualString = DateTime.Now.ToString("dd-MM-yyyy");
                    DateOnly fechaActualDateOnly = DateOnly.ParseExact(fechaActualString, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    formaPago.FechaHoraAct = DateTime.Now;

                    formaPago.EstadoId = 2;
                    _context.FormaPagos.Update(formaPago);
                    await _context.SaveChangesAsync();

                    respuesta.Cod = "000";
                    respuesta.Mensaje = "Se ha eliminado correctamente";
                }
                else
                {
                    respuesta.Cod = "999";
                    respuesta.Mensaje = "La forma de pago no existe";
                }
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = "Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("FormaPagoService", "DeleteFormaPago", ex.Message);
            }
            return respuesta;
        }
    }
}
