using System;
using System.Collections.Generic;

namespace ApiVentas.Models;

public partial class Usuario
{
    public int UsuId { get; set; }

    public string? UsuNombre { get; set; }

    public int? EmpresaId { get; set; }

    public int? EstadoId { get; set; }

    public DateTime? FechaHoraReg { get; set; }

    public DateTime? FechaHoraAct { get; set; }

    public int? UsuIdReg { get; set; }

    public int? UsuIdAct { get; set; }

    public virtual ICollection<Bodega> BodegaUsuIdActNavigations { get; set; } = new List<Bodega>();

    public virtual ICollection<Bodega> BodegaUsuIdRegNavigations { get; set; } = new List<Bodega>();

    public virtual ICollection<Categorium> CategoriumUsuIdActNavigations { get; set; } = new List<Categorium>();

    public virtual ICollection<Categorium> CategoriumUsuIdRegNavigations { get; set; } = new List<Categorium>();

    public virtual ICollection<Ciudad> CiudadUsuIdActNavigations { get; set; } = new List<Ciudad>();

    public virtual ICollection<Ciudad> CiudadUsuIdRegNavigations { get; set; } = new List<Ciudad>();

    public virtual ICollection<Cliente> ClienteUsuIdActNavigations { get; set; } = new List<Cliente>();

    public virtual ICollection<Cliente> ClienteUsuIdRegNavigations { get; set; } = new List<Cliente>();

    public virtual Empresa? Empresa { get; set; }

    public virtual ICollection<Empresa> EmpresaUsuIdActNavigations { get; set; } = new List<Empresa>();

    public virtual ICollection<Empresa> EmpresaUsuIdRegNavigations { get; set; } = new List<Empresa>();

    public virtual Estado? Estado { get; set; }

    public virtual ICollection<Estado> EstadoUsuIdActNavigations { get; set; } = new List<Estado>();

    public virtual ICollection<Estado> EstadoUsuIdRegNavigations { get; set; } = new List<Estado>();

    public virtual ICollection<FormaPago> FormaPagoUsuIdActNavigations { get; set; } = new List<FormaPago>();

    public virtual ICollection<FormaPago> FormaPagoUsuIdRegNavigations { get; set; } = new List<FormaPago>();

    public virtual ICollection<Industrium> IndustriumUsuIdActNavigations { get; set; } = new List<Industrium>();

    public virtual ICollection<Industrium> IndustriumUsuIdRegNavigations { get; set; } = new List<Industrium>();

    public virtual ICollection<Usuario> InverseUsuIdActNavigation { get; set; } = new List<Usuario>();

    public virtual ICollection<Usuario> InverseUsuIdRegNavigation { get; set; } = new List<Usuario>();

    public virtual ICollection<Modulo> ModuloUsuIdActNavigations { get; set; } = new List<Modulo>();

    public virtual ICollection<Modulo> ModuloUsuIdRegNavigations { get; set; } = new List<Modulo>();

    public virtual ICollection<MovimientoCab> MovimientoCabUsuIdActNavigations { get; set; } = new List<MovimientoCab>();

    public virtual ICollection<MovimientoCab> MovimientoCabUsuIdRegNavigations { get; set; } = new List<MovimientoCab>();

    public virtual ICollection<MovimientoDetPago> MovimientoDetPagoUsuIdActNavigations { get; set; } = new List<MovimientoDetPago>();

    public virtual ICollection<MovimientoDetPago> MovimientoDetPagoUsuIdRegNavigations { get; set; } = new List<MovimientoDetPago>();

    public virtual ICollection<MovimientoDetProducto> MovimientoDetProductoUsuIdActNavigations { get; set; } = new List<MovimientoDetProducto>();

    public virtual ICollection<MovimientoDetProducto> MovimientoDetProductoUsuIdRegNavigations { get; set; } = new List<MovimientoDetProducto>();

    public virtual ICollection<Opcion> OpcionUsuIdActNavigations { get; set; } = new List<Opcion>();

    public virtual ICollection<Opcion> OpcionUsuIdRegNavigations { get; set; } = new List<Opcion>();

    public virtual ICollection<Pai> PaiUsuIdActNavigations { get; set; } = new List<Pai>();

    public virtual ICollection<Pai> PaiUsuIdRegNavigations { get; set; } = new List<Pai>();

    public virtual ICollection<Producto> ProductoUsuIdActNavigations { get; set; } = new List<Producto>();

    public virtual ICollection<Producto> ProductoUsuIdRegNavigations { get; set; } = new List<Producto>();

    public virtual ICollection<Proveedor> ProveedorUsuIdActNavigations { get; set; } = new List<Proveedor>();

    public virtual ICollection<Proveedor> ProveedorUsuIdRegNavigations { get; set; } = new List<Proveedor>();

    public virtual ICollection<PuntoEmisionSri> PuntoEmisionSriUsuIdActNavigations { get; set; } = new List<PuntoEmisionSri>();

    public virtual ICollection<PuntoEmisionSri> PuntoEmisionSriUsuIdRegNavigations { get; set; } = new List<PuntoEmisionSri>();

    public virtual ICollection<PuntoVentum> PuntoVentumUsuIdActNavigations { get; set; } = new List<PuntoVentum>();

    public virtual ICollection<PuntoVentum> PuntoVentumUsuIdRegNavigations { get; set; } = new List<PuntoVentum>();

    public virtual ICollection<Rol> RolUsuIdActNavigations { get; set; } = new List<Rol>();

    public virtual ICollection<Rol> RolUsuIdRegNavigations { get; set; } = new List<Rol>();

    public virtual ICollection<Stock> StockUsuIdActNavigations { get; set; } = new List<Stock>();

    public virtual ICollection<Stock> StockUsuIdRegNavigations { get; set; } = new List<Stock>();

    public virtual ICollection<Sucursal> SucursalUsuIdActNavigations { get; set; } = new List<Sucursal>();

    public virtual ICollection<Sucursal> SucursalUsuIdRegNavigations { get; set; } = new List<Sucursal>();

    public virtual ICollection<TarjetaCredito> TarjetaCreditoUsuIdActNavigations { get; set; } = new List<TarjetaCredito>();

    public virtual ICollection<TarjetaCredito> TarjetaCreditoUsuIdRegNavigations { get; set; } = new List<TarjetaCredito>();

    public virtual ICollection<TipoMovimiento> TipoMovimientoUsuIdActNavigations { get; set; } = new List<TipoMovimiento>();

    public virtual ICollection<TipoMovimiento> TipoMovimientoUsuIdRegNavigations { get; set; } = new List<TipoMovimiento>();

    public virtual Usuario? UsuIdActNavigation { get; set; }

    public virtual Usuario? UsuIdRegNavigation { get; set; }

    public virtual ICollection<UsuarioPermiso> UsuarioPermisoUsuIdActNavigations { get; set; } = new List<UsuarioPermiso>();

    public virtual ICollection<UsuarioPermiso> UsuarioPermisoUsuIdRegNavigations { get; set; } = new List<UsuarioPermiso>();

    public virtual ICollection<UsuarioPermiso> UsuarioPermisoUsus { get; set; } = new List<UsuarioPermiso>();

    public virtual ICollection<UsuarioRol> UsuarioRolUsuIdActNavigations { get; set; } = new List<UsuarioRol>();

    public virtual ICollection<UsuarioRol> UsuarioRolUsuIdRegNavigations { get; set; } = new List<UsuarioRol>();

    public virtual ICollection<UsuarioRol> UsuarioRolUsus { get; set; } = new List<UsuarioRol>();
}
