namespace Api_Consultorio.Dtos
{
    public class CrearDoctorDto
    {
        public int Id { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NumeroDeTelefono { get; set; }
    }
}
