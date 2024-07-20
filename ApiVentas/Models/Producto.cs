using System;
using System.Collections.Generic;

namespace ApiVentas.Models;

public partial class Producto
{
    public int ProdId { get; set; }

    public string? ProdDescripcion { get; set; }

    public decimal? ProdUltPrecio { get; set; }

    public DateTime? FechaHoraReg { get; set; }

    public DateTime? FechaHoraAct { get; set; }

    public int? UsuIdReg { get; set; }

    public int? UsuIdAct { get; set; }

    public int? EstadoId { get; set; }

    public int? CategoriaId { get; set; }

    public int? EmpresaId { get; set; }

    public int? ProveedorId { get; set; }

    public virtual Categorium? Categoria { get; set; }

    public virtual Empresa? Empresa { get; set; }

    public virtual Estado? Estado { get; set; }

    public virtual ICollection<MovimientoDetProducto> MovimientoDetProductos { get; set; } = new List<MovimientoDetProducto>();

    public virtual Proveedor? Proveedor { get; set; }

    public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();

    public virtual Usuario? UsuIdActNavigation { get; set; }

    public virtual Usuario? UsuIdRegNavigation { get; set; }
}
