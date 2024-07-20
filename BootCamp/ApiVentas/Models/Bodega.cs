using System;
using System.Collections.Generic;

namespace ApiVentas.Models;

public partial class Bodega
{
    public int BodegaId { get; set; }

    public string? BodegaNombre { get; set; }

    public string? BodegaDireccion { get; set; }

    public string? BodegaTelefono { get; set; }

    public int? EstadoId { get; set; }

    public DateTime? FechaHoraReg { get; set; }

    public DateTime? FechaHoraAct { get; set; }

    public int? UsuIdReg { get; set; }

    public int? UsuIdAct { get; set; }

    public int? SucursalId { get; set; }

    public virtual Estado? Estado { get; set; }

    public virtual ICollection<MovimientoCab> MovimientoCabs { get; set; } = new List<MovimientoCab>();

    public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();

    public virtual Sucursal? Sucursal { get; set; }

    public virtual Usuario? UsuIdActNavigation { get; set; }

    public virtual Usuario? UsuIdRegNavigation { get; set; }
}
