using System;
using System.Collections.Generic;

namespace ApiVentas.Models;

public partial class MovimientoDetPago
{
    public int MovidetPagoId { get; set; }

    public int? MovicabId { get; set; }

    public int? FpagoId { get; set; }

    public decimal? ValorPagado { get; set; }

    public int? IndustriaId { get; set; }

    public string? Lote { get; set; }

    public string? Voucher { get; set; }

    public int? TarjetacredId { get; set; }

    public int? BancoId { get; set; }

    public int? ComprobanteId { get; set; }

    public DateTime? FechaPago { get; set; }

    public int? EstadoId { get; set; }

    public int? UsuIdReg { get; set; }

    public DateTime? FechaHoraReg { get; set; }

    public DateTime? FechaHoraAct { get; set; }

    public int? UsuIdAct { get; set; }

    public int? ClienteId { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual Estado? Estado { get; set; }

    public virtual FormaPago? Fpago { get; set; }

    public virtual Industrium? Industria { get; set; }

    public virtual MovimientoCab? Movicab { get; set; }

    public virtual TarjetaCredito? Tarjetacred { get; set; }

    public virtual Usuario? UsuIdActNavigation { get; set; }

    public virtual Usuario? UsuIdRegNavigation { get; set; }
}
