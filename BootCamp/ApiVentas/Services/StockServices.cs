using ApiVentas.DTOs;
using ApiVentas.Interfaces;
using ApiVentas.Models;
using ApiVentas.Utilitarios;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection.Metadata;

namespace ApiVentas.Services
{
    public class StockServices : IStockServices
    {
        private BaseErpContext _context;
        private StockDTO dto = new StockDTO();
        private ControlError log = new ControlError();
        private DynamicEmpty empty = new DynamicEmpty();
        public StockServices(BaseErpContext context)
        {
            this._context = context;
        }
        public async Task<Respuesta> DeleteStock(int id)
        {
            var result = new Respuesta();
            try
            {
                var stockDelete = await _context.Stocks.FirstOrDefaultAsync(x => x.StockId == id);
                if (stockDelete != null)
                {
                    stockDelete.EstadoId = 2;
                    _context.Stocks.Update(stockDelete);
                    await _context.SaveChangesAsync();
                }
                result.cod = stockDelete != null ? "000" : "111";
                result.mensaje = stockDelete != null ? "OK" : $"No se encontro registro con id: '{id}'";

            }
            catch (Exception ex)
            {
                result.cod = "999";
                result.mensaje = "Se ha presentado un exception por favor comunicarse con sistemas";
                log.LogError(this.GetType().Name, "DeleteStock", ex.Message);

            }
            return result;
        }

        public async Task<Respuesta> GetStock(string? opcion, string? data, string? data2)
        {
            var result = new Respuesta();
            Expression<Func<StockDTO, bool>> query = dto.DictionaryStock(opcion, data, data2);
            try
            {

                if (query != null)
                {
                    result.data = await (from stock in _context.Stocks
                                         join e in _context.Empresas on stock.EmpresaId equals e.EmpresaId
                                         join s in _context.Sucursals on stock.SucursalId equals s.SucursalId
                                         join b in _context.Bodegas on stock.BodegaId equals b.BodegaId
                                         join p in _context.Productos on stock.ProdId equals p.ProdId
                                         join userReg in _context.Usuarios on stock.UsuIdReg equals userReg.UsuId
                                         join est in _context.Estados on stock.EstadoId equals est.EstadoId 
                                         //join userAct in _context.Usuarios on stock.UsuIdAct equals userAct.UsuId
                                         select new StockDTO
                                         {
                                             StockId = stock.StockId,
                                             EmpresaId = e.EmpresaId,
                                             EmpresaDescrip = e.EmpresaNombre,
                                             SucursalId = stock.SucursalId,
                                             SucursalDescrip = s.SucursalNombre,
                                             BodegaId = stock.BodegaId,
                                             BodegaDescrip = b.BodegaNombre,
                                             ProdId = stock.ProdId,
                                             ProdDescrip = p.ProdDescripcion,
                                             EstadoId = stock.EstadoId,
                                             EstadoDescrip=est.EstadoDescrip,   
                                             FechaHoraReg = stock.FechaHoraReg,
                                             FechaHoraAct = stock.FechaHoraAct,
                                             UsuIdReg = stock.UsuIdReg,
                                             UsuRegDescrip = userReg.UsuNombre,
                                             UsuIdAct = stock.UsuIdAct,
                                             //UsuActDescrip = userAct.UsuNombre                              
                                         }).Where(query).ToListAsync();
                }
                result.cod = empty.IsEmpty(result.data) ? "111" : "000";
                result.mensaje = empty.IsEmpty(result.data) ? $"No se encontro registro con opcion: '{opcion}' con data: '{data}'" : "OK";
            }
            catch (Exception ex)
            {
                result.cod = "999";
                result.mensaje = "Se ha presentado un exception por favor comunicarse con sistemas";
                log.LogError(this.GetType().Name, "GetStock", ex.Message);

            }
            return result;
        }

        public async Task<Respuesta> PostStock(Stock stock)
        {
            var result = new Respuesta();
            try
            {
                var id = await _context.Stocks.OrderByDescending(x => x.StockId).Select(x => x.StockId).FirstOrDefaultAsync() + 1;
                stock.StockId = id;
                stock.FechaHoraReg = DateTime.Now;
                var validar = stock.UsuIdReg != null;
                if (validar)
                {
                    _context.Stocks.Add(stock);
                    await _context.SaveChangesAsync();
                }
                result.cod = validar ? "000" : "111";
                result.mensaje = validar ? "Ok" : "No se puede ingresar registro sin datos del usuario";
            }
            catch (Exception ex)
            {
                result.cod = "999";
                result.mensaje = "Se ha presentado un exception por favor comunicarse con sistemas";
                log.LogError(this.GetType().Name, "PostStock", ex.Message);

            }
            return result;
        }

        public async Task<Respuesta> PutStock(Stock stock)
        {
            var result = new Respuesta();
            try
            {
                var validar = await _context.Stocks.AnyAsync(x => x.StockId == stock.StockId);
                var usuarioEdit = stock.UsuIdAct;
                if (validar && usuarioEdit != null)
                {
                    result.cod = "000";
                    result.mensaje = "OK";
                    stock.UsuIdReg = await _context.Stocks.Where(x => x.StockId == stock.StockId).Select(x => x.UsuIdReg).FirstOrDefaultAsync();
                    stock.FechaHoraReg = await _context.Stocks.Where(x => x.StockId == stock.StockId).Select(x => x.FechaHoraReg).FirstOrDefaultAsync();
                    stock.FechaHoraAct = DateTime.Now;
                    _context.Stocks.Update(stock);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    result.cod = "111";
                    result.mensaje = usuarioEdit != null ? $"No se encontro registro con id: '{stock.StockId}'" : "No se puede actualizar registro sin los datos del usuario";
                }
            }
            catch (Exception ex)
            {
                result.cod = "999";
                result.mensaje = "Se ha presentado un exception por favor comunicarse con sistemas";
                log.LogError(this.GetType().Name, "PutStock", ex.Message);
            }
            return result;
        }
    }
}
