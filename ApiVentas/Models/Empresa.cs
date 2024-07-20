using System;
using System.Collections.Generic;

namespace ApiVentas.Models;

public partial class Empresa
{
    public int EmpresaId { get; set; }

    public string? EmpresaRuc { get; set; }

    public string? EmpresaNombre { get; set; }

    public string? EmpresaRazon { get; set; }

    public string? EmpresaDireccionMatriz { get; set; }

    public string? EmpresaTelefonoMatriz { get; set; }

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

    public virtual ICollection<PuntoEmisionSri> PuntoEmisionSris { get; set; } = new List<PuntoEmisionSri>();

    public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();

    public virtual ICollection<Sucursal> Sucursals { get; set; } = new List<Sucursal>();

    public virtual Usuario? UsuIdActNavigation { get; set; }

    public virtual Usuario? UsuIdRegNavigation { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
