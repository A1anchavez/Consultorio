using Consultorio.Business.Entidades;
using Consultorio.Business.Interfaces;

namespace Api_Consultorio.Dtos
{
    public class ClienteDto
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public string Direccion { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
    }
}
