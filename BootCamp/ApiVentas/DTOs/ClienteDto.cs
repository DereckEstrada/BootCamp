namespace ApiVentas.DTOs
{
    public class ClienteDto
    {
        public int ClienteID { get; set; }

        public string? CliRuc { get; set; }

        public string? CliNombre1 { get; set; }

        public string? CliNombre2 { get; set; }

        public string? CliApellido1 { get; set; }

        public string? CliApellido2 { get; set; }

        public string? CliEmail { get; set; }

        public string? CliTel { get; set; }

        public string? CliDir { get; set; }

        public string? EstadoDesc { get; set; }

        public DateTime? FecHoraReg { get; set; }

        public DateTime? FecHoraAct { get; set; }
    }
}
