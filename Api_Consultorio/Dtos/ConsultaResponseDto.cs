namespace Api_Consultorio.Dtos
{
    public class ConsultaResponseDto
    {
        public string IdCliente { get; set; }
        public string IdDoctor { get; set; }
        public DateTime? FechaConsulta { get; set; }
        public string? Motivo {get; set;}
    }
}
