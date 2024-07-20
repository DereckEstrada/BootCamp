using Microsoft.IdentityModel.Tokens;
using System.Linq.Expressions;

namespace ApiVentas.DTOs
{
    public class ProductoDTO
    {
        public int ProdId { get; set; }
        public string? ProdDescripcion { get; set; }
        public decimal? ProdUltPrecio { get; set; }
        public DateTime? FechaHoraReg { get; set; }
        public DateTime? FechaHoraAct { get; set; }
        public int? UsuIdReg { get; set; }
        public string? UsuRegDescrip { get; set; }
        public int? UsuIdAct { get; set; }
        public string? UsuActDescrip { get; set; }
        public int? EstadoId { get; set; }
        public string? EstadoDescrip { get; set; }
        public int? CategoriaId { get; set; }
        public string? CategoriaDesrip { get; set; }
        public int? EmpresaId { get; set; }
        public string? EmpresaDescrip { get; set; }
        public int? ProveedorId { get; set; }
        public string? ProveedorDescrip { get; set; }
        public Expression<Func<ProductoDTO, bool>> DictionaryProducto(string?opcion, string? data, string? data2)
        {
            bool validarOpcion=opcion.IsNullOrEmpty();
            bool validarData1=data.IsNullOrEmpty();
            bool validarData2=data2.IsNullOrEmpty();
            int.TryParse(data, out int in1);
            int.TryParse(data2, out int in2);
            decimal.TryParse(data, out decimal de1);
            decimal.TryParse(data2, out decimal de2);
            DateTime.TryParse(data, out DateTime date1);
            DateTime.TryParse(data2, out DateTime date2);
            Expression<Func<ProductoDTO, bool>> query;
            if (validarOpcion && validarData1)
            {
                 query=x => x.EstadoId == 1;
            }
            else
            {
                if (validarData2){
                    var DictionaryProducto=new Dictionary<string, Expression<Func<ProductoDTO, bool>>>();
                    DictionaryProducto.Add("id", x => x.ProdId == in1 && x.EstadoId == 1);
                    DictionaryProducto.Add("descripcion", x => x.ProdDescripcion.ToLower().Equals(data.ToLower())&& x.EstadoId == 1);
                    DictionaryProducto.Add("categoria", x => x.CategoriaId== in1 && x.EstadoId == 1);
                    DictionaryProducto.Add("empresa", x => x.EmpresaId== in1 && x.EstadoId == 1);
                    DictionaryProducto.Add("proveedor", x => x.ProveedorId== in1 && x.EstadoId == 1);
                    DictionaryProducto.Add("precio", x => x.ProdUltPrecio== de1 && x.EstadoId == 1);
                    DictionaryProducto.Add("estado", x => x.EstadoId== in1);
                    query = !validarOpcion ?DictionaryProducto.ContainsKey(opcion.ToLower())&& !validarData1 ? DictionaryProducto[opcion.ToLower()] :null: null;
                }
                else
                {
                    var DictionaryProductoDoble = new Dictionary<string, Expression<Func<ProductoDTO, bool>>>();
                    DictionaryProductoDoble.Add("precio", x => (de1<=x.ProdUltPrecio && x.ProdUltPrecio<=de2) && x.EstadoId==1);
                    DictionaryProductoDoble.Add("fechaact", x => (date1<=x.FechaHoraAct&& x.FechaHoraAct<=date2) && x.EstadoId==1);
                    query = !validarOpcion ? DictionaryProductoDoble.ContainsKey(opcion.ToLower()) && !validarData1 && !validarData2 ? DictionaryProductoDoble[opcion.ToLower()] : null : null;

                }
            }
            return query;
        }
    }
}
