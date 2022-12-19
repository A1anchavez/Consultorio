using Consultorio.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transversal.Guards;

namespace Consultorio.Business.Entidades
{
    public abstract class Persona : IEntity
    {
        private string _nombre;
        private string _apellido;

        public string Id { get; protected set; }
        public string Nombre
        {
            get => _nombre; set => _nombre = value
                .HasValue(nameof(Nombre))
                .GreaterThan(2, nameof(Nombre));
        }
        public string Apellido { get => _apellido; set => _apellido = value.HasValue(nameof(Apellido)).GreaterThan(5, nameof(Apellido)); }

        public Persona()
        {
            //Id ??= Guid.NewGuid().ToString(); //? Operador coalese
            //Id = Id==null ? Guid.NewGuid().ToString() : Id; //? Operador Ternario
            //if (Id == null) Guid.NewGuid().ToString(); //? Estructura If
        }
    }
}
