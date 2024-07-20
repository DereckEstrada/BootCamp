using System;
using System.Collections.Generic;

namespace ApiVentas.Models;

public partial class PuntoEmisionSri
{
    public int PuntoEmisionId { get; set; }

    public string? PuntoEmision { get; set; }

    public int? EmpresaId { get; set; }

    public int? SucursalId { get; set; }

    public string? CodEstablecimientoSri { get; set; }

    public int? UltSecuencia { get; set; }

    public int? EstadoId { get; set; }

    public DateTime? FechaHoraReg { get; set; }

    public DateTime? FechaHoraAct { get; set; }

    public int? UsuIdReg { get; set; }

    public int? UsuIdAct { get; set; }

    public virtual Empresa? Empresa { get; set; }

    public virtual Estado? Estado { get; set; }

    public virtual PuntoVentum? PuntoVentum { get; set; }

    public virtual Sucursal? Sucursal { get; set; }

    public virtual Usuario? UsuIdActNavigation { get; set; }

    public virtual Usuario? UsuIdRegNavigation { get; set; }
}
