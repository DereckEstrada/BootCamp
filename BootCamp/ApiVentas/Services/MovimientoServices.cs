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
    public class MovimientoServices : IMovimiento
    {
        public readonly BaseErpContext _context;
        public ControlError err = new ControlError();
        public string clase = "MovimientoServices";

        public MovimientoServices(BaseErpContext context) { _context = context; }
        public async Task<Respuesta> getListaMovimiento(int tipoConsulta, string? SecuenciaFactura, string? Cliente, string? Proveedor)
        {
            //tipoConsulta: 0 - TODAS,1 - FACTURA,2 - CLIENTE,3 - PROVEEDOR

            var resp = new Respuesta();
            var metodo = "getListaMovimiento";

            var qryMovimiento = _context.MovimientoCabs;
            var qryTipoMov = _context.TipoMovimientos;
            var qryEmpresa = _context.Empresas;
            var qrySucursal = _context.Sucursals;
            var qryBodega = _context.Bodegas;
            var qryCliente = _context.Clientes;
            var qryPuntoVta = _context.PuntoVenta;
            var qryProveedor = _context.Proveedors;
            var qryMovDetPago = _context.MovimientoDetPagos;
            var qryMovDetProd = _context.MovimientoDetProductos;
            var qryUsu = _context.Usuarios;

            try
            {
                #region 'QUERY PRINCIPAL'
                IQueryable<MovimientoDto> q = (from m in qryMovimiento
                                               join tm in qryTipoMov on m.TipomovId equals tm.TipomovId
                                               join e in qryEmpresa on m.EmpresaId equals e.EmpresaId
                                               join s in qrySucursal on m.SucursalId equals s.SucursalId
                                               join b in qryBodega on m.BodegaId equals b.BodegaId
                                               join c in qryCliente on m.ClienteId equals c.ClienteId
                                               join pv in qryPuntoVta on m.PuntovtaId equals pv.PuntovtaId
                                               join p in qryProveedor on m.ProveedorId equals p.ProvId
                                               select new MovimientoDto
                                               {
                                                   MovicabId = m.MovicabId,
                                                   TipomovDescrip = tm.TipomovDescrip,
                                                   TipomovIngEgr = m.TipomovIngEgr,
                                                   EmpresaNombre = e.EmpresaNombre,
                                                   SucursalNombre = s.SucursalNombre,
                                                   BodegaNombre = b.BodegaNombre,
                                                   SecuenciaFactura = m.SecuenciaFactura,
                                                   AutorizacionSri = m.AutorizacionSri,
                                                   ClaveAcceso = m.ClaveAcceso,
                                                   ClienteNombre = (c.ClienteApellido1 + c.ClienteApellido2 + c.ClienteNombre1 + c.ClienteNombre2),
                                                   PuntovtaNombre = pv.PuntovtaNombre,
                                                   ProveedorNombreComercial = p.ProvNomComercial,
                                                   Estado = m.EstadoId,
                                                   FechaHoraReg = m.FechaHoraReg,
                                                   FechaHoraAct = m.FechaHoraAct,
                                                   UsuReg = (from u in qryUsu where m.UsuIdReg == u.UsuId select u.UsuNombre).FirstOrDefault().ToString(),
                                                   UsuAct = (from u in qryUsu where m.UsuIdAct == u.UsuId select u.UsuNombre).FirstOrDefault().ToString(),
                                                   MovimientoDetPagos = (from dp in qryMovDetPago
                                                                         where m.MovicabId == dp.MovicabId
                                                                         select new MovimientoDetPagoDto
                                                                         {
                                                                             MovidetPagoId = dp.MovidetPagoId,
                                                                             MovicabId = dp.MovicabId,
                                                                             FpagoId = dp.FpagoId,
                                                                             ValorPagado = dp.ValorPagado,
                                                                             IndustriaId = dp.IndustriaId,
                                                                             Lote = dp.Lote,
                                                                             Voucher = dp.Voucher,
                                                                             TarjetacredId = dp.TarjetacredId,
                                                                             BancoId = dp.BancoId,
                                                                             ComprobanteId = dp.ComprobanteId,
                                                                             FechaPago = dp.FechaPago,
                                                                             EstadoId = dp.EstadoId,
                                                                             UsuIdReg = dp.UsuIdReg,
                                                                             FechaHoraReg = dp.FechaHoraReg,
                                                                             FechaHoraAct = dp.FechaHoraAct,
                                                                             UsuIdAct = dp.UsuIdAct,
                                                                             ClienteId = dp.ClienteId
                                                                         }).ToList(),
                                                   MovimientoDetProductos = (from pro in qryMovDetProd
                                                                             where m.MovicabId == pro.MovicabId
                                                                             select new MovimientoDetProductoDto
                                                                             {
                                                                                 MovidetProdId = pro.MovidetProdId,
                                                                                 MovicabId = pro.MovicabId,
                                                                                 ProductoId = pro.ProductoId,
                                                                                 Cantidad = pro.Cantidad,
                                                                                 Precio = pro.Precio,
                                                                                 EstadoId = pro.EstadoId,
                                                                                 FechaHoraReg = pro.FechaHoraReg,
                                                                                 FechaHoraAct = pro.FechaHoraAct,
                                                                                 UsuIdReg = pro.UsuIdReg,
                                                                                 UsuIdAct = pro.UsuIdAct
                                                                             }).ToList()
                                               }).AsQueryable();
                #endregion

                if (tipoConsulta == 0 && (SecuenciaFactura == null || SecuenciaFactura == "") && (Cliente == null || Cliente == "") && (Proveedor == null || Proveedor == ""))
                {
                    resp.code = "200";
                    resp.data = await q.Where(x => x.Estado == 1).ToListAsync();
                    resp.mensaje = "OK";
                }
                else if (tipoConsulta == 1 && (SecuenciaFactura != null || SecuenciaFactura != "") && (Cliente == null || Cliente == "") && (Proveedor == null || Proveedor == ""))
                {
                    resp.code = "200";
                    resp.data = await q.Where(x => x.Estado == 1 && x.SecuenciaFactura.Contains(SecuenciaFactura)).ToListAsync();
                    resp.mensaje = "OK";
                }
                else if (tipoConsulta == 2 && (SecuenciaFactura == null || SecuenciaFactura == "") && (Cliente != null || Cliente != "") && (Proveedor == null || Proveedor == ""))
                {
                    resp.code = "200";
                    resp.data = await q.Where(x => x.Estado == 1 && x.ClienteNombre.Equals(Cliente)).ToListAsync();
                    resp.mensaje = "OK";
                }
                else if (tipoConsulta == 3 && (SecuenciaFactura == null || SecuenciaFactura == "") && (Cliente == null || Cliente == "") && (Proveedor != null || Proveedor != ""))
                {
                    resp.code = "200";
                    resp.data = await q.Where(x => x.Estado == 1 && x.ProveedorNombreComercial.Equals(Proveedor)).ToListAsync();
                    resp.mensaje = "OK";
                }
                else
                {
                    resp.code = "200";
                    resp.mensaje = "No se encontraron facturas";
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
        public async Task<Respuesta> postMovimiento(MovimientoCab Movimiento)
        {

            var resp = new Respuesta();
            var qryMovCabs = _context.MovimientoCabs;
            var metodo = "postMovimiento";

            try
            {
                Movimiento.MovicabId = qryMovCabs.Max(x => x.MovicabId) + 1;
                Movimiento.FechaHoraReg = DateTime.Now;

                qryMovCabs.Add(Movimiento);

                await _context.SaveChangesAsync();

                resp.code = "200";
                resp.data = Movimiento;
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
        public async Task<Respuesta> putMovimiento(MovimientoCab Movimiento)
        {

            var resp = new Respuesta();
            var movCab = new MovimientoCab();
            var qry = _context.MovimientoCabs;
            var metodo = "putMovimiento";

            try
            {
                movCab = qry.Where(x => x.MovicabId == Movimiento.MovicabId).FirstOrDefault();

                if (movCab.MovicabId == null || movCab.MovicabId == 0)
                {
                    resp.code = "400";
                    resp.data = Movimiento;
                    resp.mensaje = "No existe el Movimiento";
                }
                else
                {

                    movCab.SecuenciaFactura = Movimiento.SecuenciaFactura;
                    movCab.FechaHoraReg = DateTime.Now;
                    movCab.Estado = Movimiento.Estado;

                    qry.Update(movCab);
                    await _context.SaveChangesAsync();

                    resp.code = "200";
                    resp.data = movCab;
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
        public async Task<Respuesta> deleteMovimiento(int MovimientoId)
        {

            var resp = new Respuesta();
            var movCab = new MovimientoCab();
            var qry = _context.MovimientoCabs;
            var metodo = "deleteMovimiento";

            try
            {
                movCab = qry.Where(x => x.MovicabId == MovimientoId && x.Estado.Equals("A")).FirstOrDefault();

                if (movCab.MovicabId == null || movCab.MovicabId == 0)
                {
                    resp.code = "400";
                    resp.data = MovimientoId;
                    resp.mensaje = "No existe o ya fue eliminada la Movimiento";
                }
                else
                {

                    movCab.FechaHoraReg = DateTime.Now;
                    movCab.EstadoId = 0;

                    qry.Update(movCab);
                    await _context.SaveChangesAsync();

                    resp.code = "200";
                    resp.data = movCab;
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
