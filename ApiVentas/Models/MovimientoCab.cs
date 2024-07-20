using System;
using System.Collections.Generic;

namespace ApiVentas.Models;

public partial class MovimientoCab
{
    public int MovicabId { get; set; }

    public int? TipomovId { get; set; }

    public int? TipomovIngEgr { get; set; }

    public int? EmpresaId { get; set; }

    public int? SucursalId { get; set; }

    public int? BodegaId { get; set; }

    public string? SecuenciaFactura { get; set; }

    public string? AutorizacionSri { get; set; }

    public string? ClaveAcceso { get; set; }

    public int? ClienteId { get; set; }

    public int? PuntovtaId { get; set; }

    public int? ProveedorId { get; set; }

    public int? EstadoId { get; set; }

    public DateTime? FechaHoraReg { get; set; }

    public DateTime? FechaHoraAct { get; set; }

    public int? UsuIdReg { get; set; }

    public int? UsuIdAct { get; set; }

    public virtual Bodega? Bodega { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual Empresa? Empresa { get; set; }

    public virtual Estado? Estado { get; set; }

    public virtual ICollection<MovimientoDetPago> MovimientoDetPagos { get; set; } = new List<MovimientoDetPago>();

    public virtual ICollection<MovimientoDetProducto> MovimientoDetProductos { get; set; } = new List<MovimientoDetProducto>();

    public virtual Proveedor? Proveedor { get; set; }

    public virtual PuntoVentum? Puntovta { get; set; }

    public virtual Sucursal? Sucursal { get; set; }

    public virtual TipoMovimiento? Tipomov { get; set; }

    public virtual Usuario? UsuIdActNavigation { get; set; }

    public virtual Usuario? UsuIdRegNavigation { get; set; }
}
