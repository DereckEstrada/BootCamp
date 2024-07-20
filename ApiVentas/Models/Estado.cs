using System;
using System.Collections.Generic;

namespace ApiVentas.Models;

public partial class Estado
{
    public int EstadoId { get; set; }

    public string? EstadoDescrip { get; set; }

    public int? EstadoFk { get; set; }

    public DateTime? FechaHoraReg { get; set; }

    public DateTime? FechaHoraAct { get; set; }

    public int? UsuIdReg { get; set; }

    public int? UsuIdAct { get; set; }

    public virtual ICollection<Bodega> Bodegas { get; set; } = new List<Bodega>();

    public virtual ICollection<Categorium> Categoria { get; set; } = new List<Categorium>();

    public virtual ICollection<Ciudad> Ciudads { get; set; } = new List<Ciudad>();

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual ICollection<Empresa> Empresas { get; set; } = new List<Empresa>();

    public virtual Estado? EstadoFkNavigation { get; set; }

    public virtual ICollection<FormaPago> FormaPagos { get; set; } = new List<FormaPago>();

    public virtual ICollection<Industrium> Industria { get; set; } = new List<Industrium>();

    public virtual ICollection<Estado> InverseEstadoFkNavigation { get; set; } = new List<Estado>();

    public virtual ICollection<Modulo> Modulos { get; set; } = new List<Modulo>();

    public virtual ICollection<MovimientoCab> MovimientoCabs { get; set; } = new List<MovimientoCab>();

    public virtual ICollection<MovimientoDetPago> MovimientoDetPagos { get; set; } = new List<MovimientoDetPago>();

    public virtual ICollection<MovimientoDetProducto> MovimientoDetProductos { get; set; } = new List<MovimientoDetProducto>();

    public virtual ICollection<Opcion> Opcions { get; set; } = new List<Opcion>();

    public virtual ICollection<Pai> Pais { get; set; } = new List<Pai>();

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();

    public virtual ICollection<Proveedor> Proveedors { get; set; } = new List<Proveedor>();

    public virtual ICollection<PuntoEmisionSri> PuntoEmisionSris { get; set; } = new List<PuntoEmisionSri>();

    public virtual ICollection<PuntoVentum> PuntoVenta { get; set; } = new List<PuntoVentum>();

    public virtual ICollection<Rol> Rols { get; set; } = new List<Rol>();

    public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();

    public virtual ICollection<Sucursal> Sucursals { get; set; } = new List<Sucursal>();

    public virtual ICollection<TarjetaCredito> TarjetaCreditos { get; set; } = new List<TarjetaCredito>();

    public virtual ICollection<TipoMovimiento> TipoMovimientos { get; set; } = new List<TipoMovimiento>();

    public virtual Usuario? UsuIdActNavigation { get; set; }

    public virtual Usuario? UsuIdRegNavigation { get; set; }

    public virtual ICollection<UsuarioPermiso> UsuarioPermisos { get; set; } = new List<UsuarioPermiso>();

    public virtual ICollection<UsuarioRol> UsuarioRols { get; set; } = new List<UsuarioRol>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
