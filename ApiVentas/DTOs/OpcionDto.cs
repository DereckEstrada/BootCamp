using ApiVentas.Models;

namespace ApiVentas.DTOs
{
    public partial class OpcionDto
    {
        public int OpcionId { get; set; }

        public string? OpcionDescripcion { get; set; }

        public short? Estado { get; set; }

        public DateTime? FechaHoraReg { get; set; }

        public DateTime? FechaHoraAct { get; set; }

        public string? UsuReg { get; set; }

        public string? UsuAct { get; set; }
        public string? ModuloDescripcion { get; set; }

        //public int? ModuloId { get; set; }

        //public virtual Modulo? Modulo { get; set; }

        //public virtual ICollection<UsuarioPermiso> UsuarioPermisos { get; set; } = new List<UsuarioPermiso>();
    }
}
