using System;
using System.Collections.Generic;

namespace ejemploEntity.Models;

public partial class Ciudad
{
    public double CiudadId { get; set; }

    public string? CiudadNombre { get; set; }

    public string? Estado { get; set; }

    public DateTime? FechaHoraReg { get; set; }

    public virtual ICollection<Sucursal> Sucursals { get; set; } = new List<Sucursal>();
}
