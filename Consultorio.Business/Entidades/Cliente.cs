using Consultorio.Business.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transversal.Guards;

namespace Consultorio.Business.Entidades
{
    public class Cliente : Persona, IEntity
    {
        private DateTime? _fechaDeNacimiento;

        public DateTime? FechaDeNacimiento { 
            get => _fechaDeNacimiento; 
            set => _fechaDeNacimiento = value.HasProperAge(nameof(FechaDeNacimiento)); 
        }
        public string Direccion { get; set; }

        //Propiedad de navegacion
        public List<Consulta>? Consultas { get; set; }

        public Cliente()
        {
            Id ??= Guid.NewGuid().ToString();
        }
        public Cliente(string nombre, string apellidos, DateTime fechaDeNacimiento, string? direccion):this()
        {
            
            Nombre = nombre;
            Apellido = apellidos;
            FechaDeNacimiento = fechaDeNacimiento;
            Direccion = direccion;

        }
        public override string ToString()
        {
            return $"{Id}, {Nombre}, {Apellido},{FechaDeNacimiento},{Direccion}";
        }
    }
}
