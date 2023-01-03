using Consultorio.Business.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transversal.Guards;

namespace Consultorio.Business.Entidades
{
    public class Consulta: IEntity
    {
        ////////////

        public string Id { get; set; }
        public string ClienteId { get; set; }//Propiedad de referencia
        public Cliente Cliente { get; set; }//Propiedad de navegacion
        public string DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        //////////
        
      
        public DateTime FechaConsulta { get; set; }//Formato Pascal

        public string Motivo { get; set; }

        public Consulta()
        {
            Id ??= Guid.NewGuid().ToString();
        }

        public Consulta(string doctorId, string clienteId, DateTime fecha_consulta, string motivo=""):this()
        {
            ClienteId = clienteId;
            DoctorId = doctorId;
            FechaConsulta = fecha_consulta.HourBetween(8,19).LaborDays().AfterNow();
            Motivo = motivo;
        }
        public override string ToString()
        {
            return $"{Cliente.Id}, {Cliente.Nombre}, {FechaConsulta},{Motivo}";
        }
    }
}
