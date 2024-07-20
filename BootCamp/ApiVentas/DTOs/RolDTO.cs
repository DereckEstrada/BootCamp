using Microsoft.IdentityModel.Tokens;
using System.Linq.Expressions;

namespace ApiVentas.DTOs
{
    public class RolDTO
    {
        public int RolId { get; set; }
        public string? RolDescripcion { get; set; }
        public int? EstadoId { get; set; }
        public string? EstadoDescrip { get; set; }
        public DateTime? FechaHoraReg { get; set; }
        public DateTime? FechaHoraAct { get; set; }
        public int? UsuIdReg { get; set; }
        public string? UsuRegDescrip { get; set; }
        public int? UsuIdAct { get; set; }
        public Expression<Func<RolDTO, bool>>? DictionaryRol(string? opcion, string? data)
        {
            bool validarOpcion = opcion.IsNullOrEmpty();
            bool validarData = data.IsNullOrEmpty();
            int.TryParse(data, out int in1);
            Expression<Func<RolDTO, bool>> query;
            if (validarOpcion)
            {
                query = x => x.EstadoId == 1;
            }
            else
            {
                var DictionaryRol= new Dictionary<string, Expression<Func<RolDTO, bool>>>();
                DictionaryRol.Add("id", x => x.RolId== in1 && x.EstadoId == 1);
                DictionaryRol.Add("descripcion", x => x.RolDescripcion.ToLower().Equals(data.ToLower()) && x.EstadoId == 1);
                DictionaryRol.Add("estado", x => x.EstadoId == in1);
                query = !validarOpcion ? DictionaryRol.ContainsKey(opcion.ToLower()) && !validarData ? DictionaryRol[opcion.ToLower()] : null : null;
            }
            return query;
        }
    }
}
