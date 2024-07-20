using System;
using System.Collections.Generic;

namespace ApiVentas.Models;

public partial class Sucursal
{
    public int SucursalId { get; set; }

    public string? SucursalRuc { get; set; }

    public string? SucursalNombre { get; set; }

    public string? SucursalDireccion { get; set; }

    public string? SucursalTelefono { get; set; }

    public int? EstadoId { get; set; }

    public DateTime? FechaHoraReg { get; set; }

    public int? UsuIdReg { get; set; }

    public DateTime? FechaHoraAct { get; set; }

    public int? UsuIdAct { get; set; }

    public int? EmpresaId { get; set; }

    public string? CodEstablecimientoSri { get; set; }

    public virtual ICollection<Bodega> Bodegas { get; set; } = new List<Bodega>();

    public virtual Empresa? Empresa { get; set; }

    public virtual Estado? Estado { get; set; }

    public virtual ICollection<MovimientoCab> MovimientoCabs { get; set; } = new List<MovimientoCab>();

    public virtual ICollection<PuntoEmisionSri> PuntoEmisionSris { get; set; } = new List<PuntoEmisionSri>();

    public virtual ICollection<PuntoVentum> PuntoVenta { get; set; } = new List<PuntoVentum>();

    public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();

    public virtual Usuario? UsuIdActNavigation { get; set; }

    public virtual Usuario? UsuIdRegNavigation { get; set; }
}
