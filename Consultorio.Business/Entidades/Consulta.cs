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
    public class Consulta : IEntity
    {
        private DateTime _fechaConsulta;

        ////////////

        public string Id { get; set; }
        public string ClienteId { get; set; }//Propiedad de referencia
        public Cliente Cliente { get; set; }//Propiedad de navegacion
        public string DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        //////////


        public DateTime FechaConsulta 
        { get => _fechaConsulta;
            set => _fechaConsulta = value.AfterNow(nameof(FechaConsulta)).HourBetween(8, 19).LaborDays();
        }//Formato Pascal

        public string Motivo { get; set; }

        public Consulta()
        {
            Id ??= Guid.NewGuid().ToString();
        }

        //public Consulta(string clienteId, Cliente cliente, string doctorId, Doctor doctor, DateTime fecha_consulta, string motivo) : this()
        //{
        //    ClienteId = clienteId;
        //    Cliente = cliente;
        //    DoctorId = doctorId;
        //    Doctor = doctor;
        //    FechaConsulta = fecha_consulta.HourBetween(8, 19).LaborDays().AfterNow(fecha_consulta);
        //    Motivo = motivo;
        //}
        public override string ToString()
        {
            return $"{Cliente.Id}, {Cliente.Nombre}, {FechaConsulta},{Motivo}";
        }
    }
}
