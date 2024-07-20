using ApiVentas.Interfaces;
using ApiVentas.Models;
using ApiVentas.Utilitarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiVentas.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockServices _stock;
        private ControlError log = new ControlError();
        public StockController(IStockServices stock)
        {
            this._stock = stock;
        }
        [HttpGet]
        [Route("GetStock")]
        public async Task<Respuesta> GetStock(string? opcion, string? data, string? data2)
        {
            var result = new Respuesta();
            try
            {
                result = await _stock.GetStock(opcion, data, data2);
            }
            catch (Exception ex)
            {
                log.LogError(this.GetType().Name, "GetStock", ex.Message);
            }
            return result;
        }
        [HttpPost]
        [Route("PostStock")]
        public async Task<Respuesta> PostStock([FromBody] Stock stock)
        {
            var result = new Respuesta();
            try
            {
                result = await _stock.PostStock(stock);
            }
            catch (Exception ex)
            {
                log.LogError(this.GetType().Name, "PostStock", ex.Message);
            }
            return result;
        }
        [HttpPut]
        [Route("PutStock")]
        public async Task<Respuesta> PutStock([FromBody] Stock stock)
        {
            var result = new Respuesta();
            try
            {
                result = await _stock.PutStock(stock);
            }
            catch (Exception ex)
            {
                log.LogError(this.GetType().Name, "PutStock", ex.Message);
            }
            return result;
        }
        [HttpDelete]
        [Route("DeleteStock")]
        public async Task<Respuesta> DeleteStock(int id)
        {
            var result = new Respuesta();
            try
            {
                result = await _stock.DeleteStock(id);
            }
            catch (Exception ex)
            {
                log.LogError(this.GetType().Name, "DeleteStock", ex.Message);
            }
            return result;
        }
    }
}
