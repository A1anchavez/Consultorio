using Consultorio.Business.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transversal.Guards;

namespace Consultorio.Business.Entidades
{
    public class Usuario : IEntity
    {
        public string Id { get; private set; }
        public string _nombreUsuario;
        public string _contraseña;
        public string NombreUsuario
        {
            get => _nombreUsuario; set => _nombreUsuario = value
                .HasValue(nameof(NombreUsuario))
                .GreaterThan(2, nameof(NombreUsuario));
        }
        public string Contraseña
        {
            get => _contraseña; set => _contraseña = value
                .HasValue(nameof(Contraseña))
                .GreaterThan(2, nameof(Contraseña));
        }
        public string Rol { get; set; }
        public Usuario()
        {

        }
        public Usuario(string id, string nombre, string contraseña, string rol)
        {
            Id = id;
            NombreUsuario = nombre;
            Contraseña = contraseña;
            Rol = rol;
        }
    }
}
