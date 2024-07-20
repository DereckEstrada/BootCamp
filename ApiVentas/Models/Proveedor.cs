using System;
using System.Collections.Generic;

namespace ApiVentas.Models;

public partial class Proveedor
{
    public int ProvId { get; set; }

    public string? ProvRuc { get; set; }

    public string? ProvNomComercial { get; set; }

    public string? ProvRazon { get; set; }

    public string? ProvDireccion { get; set; }

    public string? ProvTelefono { get; set; }

    public int? CiudadId { get; set; }

    public int? EstadoId { get; set; }

    public DateTime? FechaHoraReg { get; set; }

    public DateTime? FechaHoraAct { get; set; }

    public int? UsuIdReg { get; set; }

    public int? UsuIdAct { get; set; }

    public virtual Ciudad? Ciudad { get; set; }

    public virtual Estado? Estado { get; set; }

    public virtual ICollection<MovimientoCab> MovimientoCabs { get; set; } = new List<MovimientoCab>();

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();

    public virtual Usuario? UsuIdActNavigation { get; set; }

    public virtual Usuario? UsuIdRegNavigation { get; set; }
}
