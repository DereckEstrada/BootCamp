using ApiVentas.Models;

namespace ApiVentas.DTOs
{
    public partial class MovimientoDto
    {
        public int MovicabId { get; set; }

        public string? TipomovDescrip { get; set; }

        public int? TipomovIngEgr { get; set; }

        public string? EmpresaNombre { get; set; }

        public string? SucursalNombre { get; set; }

        public string? BodegaNombre { get; set; }

        public string? SecuenciaFactura { get; set; }

        public string? AutorizacionSri { get; set; }

        public string? ClaveAcceso { get; set; }

        public string? ClienteNombre { get; set; }

        public string? PuntovtaNombre { get; set; }

        public string? ProveedorNombreComercial { get; set; }

        public int? Estado { get; set; }

        public DateTime? FechaHoraReg { get; set; }

        public DateTime? FechaHoraAct { get; set; }

        public string? UsuReg { get; set; }

        public string? UsuAct { get; set; }

        //public virtual Cliente? Cliente { get; set; }

        //public virtual Empresa? Empresa { get; set; }

        public virtual ICollection<MovimientoDetPagoDto> MovimientoDetPagos { get; set; } = new List<MovimientoDetPagoDto>();

        public virtual ICollection<MovimientoDetProductoDto> MovimientoDetProductos { get; set; } = new List<MovimientoDetProductoDto>();

        //public virtual Proveedor? Proveedor { get; set; }

        //public virtual Sucursal? Sucursal { get; set; }

        //public virtual TipoMovimiento? Tipomov { get; set; }

        //public virtual Usuario? UsuIdRegNavigation { get; set; }
    }
}
