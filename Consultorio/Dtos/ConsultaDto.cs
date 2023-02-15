using Consultorio.Business.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Dtos
{
    public class ConsultaDto
    {
        public string Id { get; set; }
        public string ClienteId { get; set; }//Propiedad de referencia
        public Cliente Cliente { get; set; }//Propiedad de navegacion
        public string DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public DateTime FechaConsulta { get; set; }
        public string Motivo { get; set; }

    }
}
