using Consultorio.Business.Entidades;

namespace Api_Consultorio.Dtos
{
    public class CrearConsultaDto
    {
        public string ClienteId { get; set; }
        public string DoctorId { get; set; }
        public DateTime FechaConsulta { get; set; }
        public string? Motivo { get; set; }
    }
}
