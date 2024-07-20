using ApiVentas.Models;

namespace ApiVentas.DTOs
{
    public partial class PaiDto
    {
        public int PaisId { get; set; }

        public string? PaisNombre { get; set; }

        public int? Estado { get; set; }

        public DateTime? FechaHoraReg { get; set; }

        public DateTime? FechaHoraAct { get; set; }

        //public int? UsuIdReg { get; set; }

        //public int? UsuIdAct { get; set; }
        public string? UsuReg { get; set; }

        public string? UsuAct { get; set; }

        // public virtual ICollection<Ciudad> Ciudads { get; set; } = new List<Ciudad>();

        //public string? Ciudads { get; set; }
    }
}
