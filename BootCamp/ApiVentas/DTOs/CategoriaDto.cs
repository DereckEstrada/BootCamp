namespace ApiVentas.DTOs
{
    public class CategoriaDto
    {
        public int CategoriaID { get; set; }

        public string? CategDescrip { get; set; }

        public string? EstadoDesc { get; set; }

        public DateTime? FecHoraReg { get; set; }

        public DateTime? FecHoraAct { get; set; }
    }
}
