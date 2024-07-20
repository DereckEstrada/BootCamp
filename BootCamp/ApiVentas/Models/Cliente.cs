using System;
using System.Collections.Generic;

namespace ApiVentas.Models;

public partial class Cliente
{
    public int ClienteId { get; set; }

    public string? ClienteRuc { get; set; }

    public string? ClienteNombre1 { get; set; }

    public string? ClienteNombre2 { get; set; }

    public string? ClienteApellido1 { get; set; }

    public string? ClienteApellido2 { get; set; }

    public string? ClienteEmail { get; set; }

    public string? ClienteTelefono { get; set; }

    public string? ClienteDireccion { get; set; }

    public int? EstadoId { get; set; }

    public DateTime? FechaHoraReg { get; set; }

    public DateTime? FechaHoraAct { get; set; }

    public int? UsuIdReg { get; set; }

    public int? UsuIdAct { get; set; }

    public virtual Estado? Estado { get; set; }

    public virtual ICollection<MovimientoCab> MovimientoCabs { get; set; } = new List<MovimientoCab>();

    public virtual ICollection<MovimientoDetPago> MovimientoDetPagos { get; set; } = new List<MovimientoDetPago>();

    public virtual Usuario? UsuIdActNavigation { get; set; }

    public virtual Usuario? UsuIdRegNavigation { get; set; }
}
