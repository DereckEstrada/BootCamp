using System;
using System.Collections.Generic;

namespace ApiVentas.Models;

public partial class Stock
{
    public long StockId { get; set; }

    public int? EmpresaId { get; set; }

    public int? SucursalId { get; set; }

    public int? BodegaId { get; set; }

    public int? ProdId { get; set; }

    public int? CantidadStock { get; set; }

    public int? EstadoId { get; set; }

    public DateTime? FechaHoraReg { get; set; }

    public DateTime? FechaHoraAct { get; set; }

    public int? UsuIdReg { get; set; }

    public int? UsuIdAct { get; set; }

    public virtual Bodega? Bodega { get; set; }

    public virtual Empresa? Empresa { get; set; }

    public virtual Estado? Estado { get; set; }

    public virtual Producto? Prod { get; set; }

    public virtual Sucursal? Sucursal { get; set; }

    public virtual Usuario? UsuIdActNavigation { get; set; }

    public virtual Usuario? UsuIdRegNavigation { get; set; }
}
