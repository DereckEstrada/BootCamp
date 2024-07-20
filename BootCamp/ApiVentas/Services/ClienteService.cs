using ApiVentas.Interfaces;
using ApiVentas.Models;
using ApiVentas.Utilitarios;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using ApiVentas.DTOs;

namespace ApiVentas.Services
{
    public class ClienteServices : ICliente
    {
        private readonly BaseErpContext _context;
        private ControlError Log = new ControlError();

        public ClienteServices(BaseErpContext context)
        {
            this._context = context;
        }

        public async Task<Respuesta> GetCliente(double clienteID, string? clienteNombre, double cedula)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = from cl in _context.Clientes
                            join es in _context.Estados on cl.EstadoId equals es.EstadoId
                            where es.EstadoId == 1
                            select new ClienteDto
                            {
                                ClienteID = cl.ClienteId,
                                CliRuc = cl.ClienteRuc,
                                CliNombre1 = cl.ClienteNombre1,
                                CliNombre2 = cl.ClienteNombre2,
                                CliApellido1 = cl.ClienteApellido1,
                                CliApellido2 = cl.ClienteApellido2,
                                CliEmail = cl.ClienteEmail,
                                CliTel = cl.ClienteTelefono,
                                CliDir = cl.ClienteDireccion,
                                EstadoDesc = es.EstadoDescrip,
                                FecHoraReg = cl.FechaHoraReg,
                                FecHoraAct = cl.FechaHoraAct
                            };

                if (clienteID != 0 && !string.IsNullOrEmpty(clienteNombre) && cedula != 0)
                {
                    respuesta.Data = await query.Where(cl => cl.ClienteID == clienteID && cl.CliNombre1.Contains(clienteNombre) && cl.CliRuc == cedula.ToString()).ToListAsync();
                }
                else if (clienteID != 0 && !string.IsNullOrEmpty(clienteNombre))
                {
                    respuesta.Data = await query.Where(cl => cl.ClienteID == clienteID && cl.CliNombre1.Contains(clienteNombre)).ToListAsync();
                }
                else if (clienteID != 0 && cedula != 0)
                {
                    respuesta.Data = await query.Where(cl => cl.ClienteID == clienteID && cl.CliRuc == cedula.ToString()).ToListAsync();
                }
                else if (!string.IsNullOrEmpty(clienteNombre) && cedula != 0)
                {
                    respuesta.Data = await query.Where(cl => cl.CliNombre1.Contains(clienteNombre) && cl.CliRuc == cedula.ToString()).ToListAsync();
                }
                else if (clienteID != 0)
                {
                    respuesta.Data = await query.Where(cl => cl.ClienteID == clienteID).ToListAsync();
                }
                else if (!string.IsNullOrEmpty(clienteNombre))
                {
                    respuesta.Data = await query.Where(cl => cl.CliNombre1.Contains(clienteNombre)).ToListAsync();
                }
                else if (cedula != 0)
                {
                    respuesta.Data = await query.Where(cl => cl.CliRuc == cedula.ToString()).ToListAsync();
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
                Log.LogErrorMetodos("ClienteServices", "GetCliente", ex.Message);
            }

            return respuesta;
        }


        public async Task<Respuesta> PostCliente(Cliente cliente)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = _context.Clientes.OrderByDescending(x => x.ClienteId).Select(x => x.ClienteId).FirstOrDefault();
                cliente.ClienteId = query == 0 ? 1 : Convert.ToInt32(query) + 1;
                cliente.FechaHoraReg = DateTime.Now;

                _context.Clientes.Add(cliente);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se insertó correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("ClienteServices", "PostCliente", ex.Message);
            }
            return respuesta;
        }


        public async Task<Respuesta> PutCliente(Cliente cliente)
        {
            var respuesta = new Respuesta();
            try
            {
                bool existingCliente = await _context.Clientes.AnyAsync();
                if (existingCliente)
                {

                    cliente.FechaHoraAct = DateTime.Now;

                    _context.Clientes.Update(cliente);
                    await _context.SaveChangesAsync();

                    respuesta.Cod = "000";
                    respuesta.Mensaje = "Se actualizó correctamente";
                }
                else
                {
                    respuesta.Cod = "999";
                    respuesta.Mensaje = "El cliente no existe";
                }
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("ClienteServices", "PutCliente", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> DeleteCliente(Cliente cliente)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                bool existingCliente = await _context.Clientes.AnyAsync();
                if (existingCliente)
                {

                    cliente.FechaHoraAct = DateTime.Now;

                    cliente.EstadoId = 2;
                    
                    _context.Clientes.Update(cliente);
                    await _context.SaveChangesAsync();

                    respuesta.Cod = "000";
                    respuesta.Mensaje = "Se ha eliminado correctamente";
                }
                else
                {
                    respuesta.Cod = "999";
                    respuesta.Mensaje = "El cliente no existe";
                }
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = "Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("ClienteServices", "DeleteCliente", ex.Message);
            }
            return respuesta;
        }
    }
}
