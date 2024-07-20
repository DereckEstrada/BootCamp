using Microsoft.IdentityModel.Tokens;
using System.Linq.Expressions;

namespace ApiVentas.DTOs
{
    public class PuntoVentaDTO
    {
        public int PuntovtaId { get; set; }
        public string? PuntovtaNombre { get; set; }
        public int? PuntoEmisionId { get; set; }
        public string? PuntoEmisionDescrip{ get; set; }
        public int? EstadoId { get; set; }
        public string? EstadoDescrip { get; set; }
        public DateTime? FechaHoraReg { get; set; }
        public DateTime? FechaHoraAct { get; set; }
        public int? UsuIdReg { get; set; }
        public string? UsuRegDescrip { get; set; }
        public int? UsuIdAct { get; set; }
        public string? UsuActDescrip { get; set; }
        public int? SucursalId { get; set; }
        public string? SucursalDescrip{ get; set; }
        public Expression<Func<PuntoVentaDTO, bool>> DictionaryPuntoVenta(string?opcion, string? data)
        {
            bool validarOpcion = opcion.IsNullOrEmpty();
            bool validarData = data.IsNullOrEmpty();
            int.TryParse(data, out int in1);
            Expression<Func<PuntoVentaDTO, bool>> query;
            if (validarOpcion)
            {
                query = x => x.EstadoId==1;
            }
            else
            {
                var DictionaryPuntoVenta= new Dictionary<string, Expression<Func<PuntoVentaDTO, bool>>>();
                DictionaryPuntoVenta.Add("id", x => x.PuntovtaId== in1 && x.EstadoId==1);
                DictionaryPuntoVenta.Add("nombre", x => x.PuntovtaNombre.ToLower().Equals(data.ToLower()) && x.EstadoId==1);
                DictionaryPuntoVenta.Add("puntoemision", x => x.PuntoEmisionId==in1 && x.EstadoId==1);
                DictionaryPuntoVenta.Add("estado", x => x.EstadoId==in1);
                query = !validarOpcion ? DictionaryPuntoVenta.ContainsKey(opcion.ToLower()) && !validarData ? DictionaryPuntoVenta[opcion.ToLower()] : null : null;
            }
            return query;
        }
    }
}
