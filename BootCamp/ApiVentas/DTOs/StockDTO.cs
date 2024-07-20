using ApiVentas.Models;
using Microsoft.IdentityModel.Tokens;
using System.Linq.Expressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ApiVentas.DTOs
{
    public class StockDTO
    {
        public long StockId { get; set; }
        public int? EmpresaId { get; set; }
        public string? EmpresaDescrip{ get; set; }
        public int? SucursalId { get; set; }
        public string? SucursalDescrip { get; set; }
        public int? BodegaId { get; set; }
        public string? BodegaDescrip{ get; set; }
        public int? ProdId { get; set; }
        public string? ProdDescrip{ get; set; }
        public int? CantidadStock { get; set; }
        public int? EstadoId { get; set; }
        public string? EstadoDescrip { get; set; }
        public DateTime? FechaHoraReg { get; set; }
        public DateTime? FechaHoraAct { get; set; }
        public int? UsuIdReg { get; set; }
        public string? UsuRegDescrip { get; set; }
        public int? UsuIdAct { get; set; }
        public string? UsuActDescrip { get; set; }
        public Expression<Func<StockDTO, bool>> DictionaryStock(string? opcion, string? data, string?data2)
        {
            bool validarOpcion = opcion.IsNullOrEmpty();
            bool validarData = data.IsNullOrEmpty();
            bool validarData2=data2.IsNullOrEmpty();
            int.TryParse(data, out int in1);
            int.TryParse(data2, out int in2);
            Expression<Func<StockDTO, bool>> query;
            if (validarOpcion)
            {
                query = x => x.EstadoId == 1;
            }
            else if(validarData2)
            {
                var DictionaryStock= new Dictionary<string, Expression<Func<StockDTO, bool>>>();
                DictionaryStock.Add("id", x => x.StockId== in1 && x.EstadoId == 1);
                DictionaryStock.Add("empresa", x => x.EmpresaId==in1 && x.EstadoId == 1);
                DictionaryStock.Add("sucursal", x => x.SucursalId== in1 && x.EstadoId == 1);
                DictionaryStock.Add("producto", x => x.ProdId== in1 && x.EstadoId == 1);
                DictionaryStock.Add("sucursal", x => x.SucursalId== in1 && x.EstadoId == 1);
                DictionaryStock.Add("cantidadstock", x => x.CantidadStock== in1 && x.EstadoId == 1);
                DictionaryStock.Add("estado", x => x.EstadoId == in1);
                query = !validarOpcion ? DictionaryStock.ContainsKey(opcion.ToLower()) && !validarData ? DictionaryStock[opcion.ToLower()] : null : null;
            }
            else
            {
                var DictionaryStockDoble= new Dictionary<string, Expression<Func<StockDTO, bool>>>();
                DictionaryStockDoble.Add("cantidadstock", x => in1 <= x.CantidadStock && x.CantidadStock <= in2);
                query = !validarOpcion ?DictionaryStockDoble.ContainsKey(opcion.ToLower()) && !validarData &&!validarData2 ? DictionaryStockDoble[opcion.ToLower()] :null: null;
            }
            return query;
        } 
    }
}
