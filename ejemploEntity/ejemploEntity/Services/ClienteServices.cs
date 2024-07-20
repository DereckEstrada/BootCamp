using ejemploEntity.Interfaces;
using ejemploEntity.Models;
using Microsoft.EntityFrameworkCore;

namespace ejemploEntity.Services
{
    public class ClienteServices : ICliente
    {
        public readonly TestContext _context;

        public ClienteServices(TestContext context) { _context = context; }
        public async Task<Respuesta> getListaClientes(int clienteId, string? nombreCliente, Double identificacion)
        {
            var resp = new Respuesta();

            var qry = _context.Clientes;

            try
            {
                if (clienteId == 0 && nombreCliente == null && identificacion == 0)
                {
                    resp.code = "200";
                    resp.data = await qry.Where(x => x.Estado.Equals("A")).ToListAsync();
                    resp.mensaje = "OK";
                }
                else if (clienteId != 0 && nombreCliente == null && identificacion == 0)
                {
                    resp.code = "200";
                    resp.data = await qry.Where(x => x.Estado.Equals("A") && x.ClienteId.Equals(clienteId)).ToListAsync();
                    resp.mensaje = "OK";
                }
                else if (clienteId == 0 && nombreCliente != null && identificacion == 0)
                {
                    resp.code = "200";
                    resp.data = await qry.Where(x => x.Estado.Equals("A") && x.ClienteNombre.Equals(nombreCliente)).ToListAsync();
                    resp.mensaje = "OK";
                }
                else if (clienteId == 0 && nombreCliente == null && identificacion > 0)
                {
                    resp.code = "200";
                    resp.data = await qry.Where(x => x.Estado.Equals("A") && x.Cedula.Equals(identificacion)).ToListAsync();
                    resp.mensaje = "OK";
                }
                else if (clienteId > 0 && nombreCliente != null && identificacion > 0)
                {
                    resp.code = "200";
                    resp.data = await qry.Where(x => x.Estado.Equals("A") && x.Cedula.Equals(clienteId) && x.ClienteNombre.Equals(nombreCliente) && x.Cedula.Equals(identificacion)).ToListAsync();
                    resp.mensaje = "OK";
                }

            }
            catch (Exception ex)
            {
                resp.code = "400";
                resp.mensaje = $"Error en ClienteServicio: {ex.Message}";
            }

            return resp;
        }
        public async Task<Respuesta> postCliente(Cliente cliente)
        {

            var resp = new Respuesta();
            var qry = _context.Clientes;

            try
            {
                cliente.ClienteId = qry.Max(x => x.ClienteId) + 1;
                cliente.FechaHoraReg = DateTime.Now;

                qry.Add(cliente);
                await _context.SaveChangesAsync();

                resp.code = "200";
                resp.data = cliente;
                resp.mensaje = "Registrado exitosamente";

            }
            catch (Exception ex)
            {
                resp.code = "400";
                resp.mensaje = $"Error en service: {ex.Message}";
            }

            return resp;
        }
        public async Task<Respuesta> putCliente(Cliente cliente)
        {

            var resp = new Respuesta();
            var cli = new Cliente();
            var qry = _context.Clientes;

            try
            {
                cli = qry.Where(x => x.ClienteId == cliente.ClienteId).FirstOrDefault();

                if (cli.ClienteId == null || cli.ClienteId == 0)
                {
                    resp.code = "400";
                    resp.data = cliente;
                    resp.mensaje = "No existe el producto";
                }
                else
                {

                    cli.ClienteNombre = cliente.ClienteNombre;
                    cli.Cedula = cliente.Cedula;
                    cli.FechaHoraReg = DateTime.Now;
                    cli.Estado = cliente.Estado;

                    qry.Update(cli);
                    await _context.SaveChangesAsync();

                    resp.code = "200";
                    resp.data = cli;
                    resp.mensaje = "Actualizado exitosamente";
                }

            }
            catch (Exception ex)
            {
                resp.code = "400";
                resp.mensaje = $"Error en servicio: {ex.Message}";
            }

            return resp;
        }
    }
}
