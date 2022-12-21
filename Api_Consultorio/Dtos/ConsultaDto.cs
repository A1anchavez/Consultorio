﻿using Consultorio.Business.Entidades;

namespace Api_Consultorio.Dtos
{
    public class ConsultaDto
    {
        public string Id { get; set; }
        public string ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public string DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public DateTime FechaConsulta { get; set; }
        public string Motivo { get; set; }
    }
}
