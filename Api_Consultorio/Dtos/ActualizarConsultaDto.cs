namespace Api_Consultorio.Dtos
{
    public class ActualizarConsultaDto
    {
        public string? DoctorId { get; set; }
        public DateTime? FechaDeConsulta { get; set; }
        public string? Motivo { get; set; }
    }
}
