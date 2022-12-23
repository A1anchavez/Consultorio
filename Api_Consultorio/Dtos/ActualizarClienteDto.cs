using System;

namespace Api_Consultorio.Dtos
{
    public class ActualizarClienteDto
    {
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public DateTime? FechaDeNacimiento { get; set; }
        public string? Direccion { get; set; }
    }
}
