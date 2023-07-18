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
    public class Doctor: Persona, IEntity
    {
        private string _cedula;
        private string _numeroDeTelefono;
        public string Cedula
        {
            get => _cedula;
            set => _cedula = value.IsNumber(nameof(Cedula)).EqualsNumber(16, nameof(Cedula)).HasWhiteSpace(nameof(Cedula)).HasDash(nameof(Cedula));
        }
        public string NumeroDeTelefono { 
            get => _numeroDeTelefono; 
            set => _numeroDeTelefono = value.IsNumber(nameof(NumeroDeTelefono)).EqualsNumber(10,nameof(NumeroDeTelefono)).HasWhiteSpace(nameof(NumeroDeTelefono)); 
        }
        public List<Consulta>? Consultas { get; set; }

        public Doctor()
        {
            Id ??= Guid.NewGuid().ToString();
        }
        public Doctor(string cedula, string nombre, string apellidos, string numeroDeTelefono)
        {
            Cedula = cedula;
            Nombre = nombre;
            Apellido = apellidos;
            NumeroDeTelefono = numeroDeTelefono;

        }

        public override string ToString()
        {
            return $"{Id}, {Cedula}, {Nombre}, {Apellido},{NumeroDeTelefono}";
        }
    }
}
