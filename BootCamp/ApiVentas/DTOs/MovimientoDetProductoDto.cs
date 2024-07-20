using ApiVentas.Models;

namespace ApiVentas.DTOs
{
    public partial class MovimientoDetProductoDto
    {
        public int MovidetProdId { get; set; }

        public int? MovicabId { get; set; }

        public int? ProductoId { get; set; }

        public int? Cantidad { get; set; }

        public decimal? Precio { get; set; }

        public int? EstadoId { get; set; }

        public DateTime? FechaHoraReg { get; set; }

        public DateTime? FechaHoraAct { get; set; }

        public int? UsuIdReg { get; set; }

        public int? UsuIdAct { get; set; }

        //public virtual Estado? Estado { get; set; }

        //public virtual MovimientoCab? Movicab { get; set; }

        //public virtual Producto? Producto { get; set; }

        //public virtual Usuario? UsuIdActNavigation { get; set; }

        //public virtual Usuario? UsuIdRegNavigation { get; set; }
    }
}
