using Api_Consultorio.Dtos;
using Consultorio.Business.Entidades;
using Consultorio.Business.Interfaces;
using Infraestructura.SQLServer.Contextos;
using Microsoft.AspNetCore.Mvc;

namespace Api_Consultorio.Controllers
{
    [ApiController]
    [Route("doctor")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorRepository _repo;
        private readonly ILogger<DoctorController> logger;

        public DoctorController(IDoctorRepository repo, ILogger<DoctorController> logger)
        {
            _repo = repo;
            this.logger = logger;
        }

        [HttpPost()]
        public ActionResult CrearDoctor([FromBody] DoctorDto doctorDto)
        {
            var doctor = new Doctor() { 
            Id = doctorDto.Id,
            Cedula = doctorDto.Cedula,
            Nombre = doctorDto.Nombre,
            Apellido = doctorDto.Apellido,
            NumeroDeTelefono = doctorDto.NumeroDeTelefono
            };
            _repo.Agregar(doctor);
            _repo.GuardarCambios();

            return Ok(doctor);
        }
        [HttpGet]
        public ActionResult consultarDoctor(/*[FromQuery] ClienteParameters clienteParameters*/)
        {
            var doctor = _repo.Consultar(/*clienteParameters*/);
            return Ok(doctor);
        }

        [HttpGet("{Id}")]
        public ActionResult ConsultarDoctor([FromRoute] string id)
        {
            Doctor doctor = _repo.Consultar().Where(x => x.Id == id).FirstOrDefault();//Todo: Refactorizar
            try
            {
                if (doctor == null)
                {
                    return NotFound("Doctor no encontrado");
                }



                return Ok(doctor);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);

                return StatusCode(500,
                    new
                    {
                        Error = "410025",
                        Mensaje = "Error: Doctor no fue procesado",
                        Data = doctor
                    });
            }
        }

        /*
         * Espacio para metodo actualizar
         * 
         */
        //Eliminar una consulta
        [HttpDelete("{Id}")]
        public ActionResult EliminarDoctor([FromRoute] string id)
        {
            Doctor doctor = _repo.ConsultarPorId(id);
            try
            {
                if (doctor == null)
                {
                    return NotFound("Doctor no encontrado");
                }
                _repo.Eliminar(id, doctor);
            }
            catch
            {
                return StatusCode(500,
                    new
                    {
                        Error = "410025",
                        Mensaje = "Error: Doctor no fue procesado",
                        Data = doctor
                    });
            }
            return Ok(doctor);
        }
    }
}
