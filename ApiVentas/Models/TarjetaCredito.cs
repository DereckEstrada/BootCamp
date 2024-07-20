using System;
using System.Collections.Generic;

namespace ApiVentas.Models;

public partial class TarjetaCredito
{
    public int TarjetacredId { get; set; }

    public string? TarjetacredDescripcion { get; set; }

    public int? IndustriaId { get; set; }

    public DateTime? FechaHoraReg { get; set; }

    public DateTime? FechaHoraAct { get; set; }

    public int? UsuIdReg { get; set; }

    public int? EstadoId { get; set; }

    public int? UsuIdAct { get; set; }

    public virtual Estado? Estado { get; set; }

    public virtual Industrium? Industria { get; set; }

    public virtual ICollection<MovimientoDetPago> MovimientoDetPagos { get; set; } = new List<MovimientoDetPago>();

    public virtual Usuario? UsuIdActNavigation { get; set; }

    public virtual Usuario? UsuIdRegNavigation { get; set; }
}
