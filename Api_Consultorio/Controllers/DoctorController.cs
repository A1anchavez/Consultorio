using Api_Consultorio.Dtos;
using Consultorio.Business.Entidades;
using Consultorio.Business.Interfaces.Repositorios;
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

        //Agregar un Doctor
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

        //Consultar un Doctor
        [HttpGet]
        public ActionResult consultarDoctor(/*[FromQuery] ClienteParameters clienteParameters*/)
        {
            var doctor = _repo.Consultar(/*clienteParameters*/);
            return Ok(doctor);
        }
        //Consultar un Doctor por Id
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

        //Actualizar un Doctor
        [HttpPut("{id}")]
        public ActionResult ActualizarDoctor(string id, [FromBody] ActualizarDoctorDto doctor)
        {
            var _doctor = _repo.ConsultarPorId(id);
            try
            {
                if (_doctor == null)
                {
                    return NotFound("Cliente no encontrado");
                }

                _doctor.Nombre = doctor.Nombre ?? _doctor.Nombre;
                _doctor.Apellido = doctor.Apellido ?? _doctor.Apellido;
                _doctor.Cedula = doctor.Cedula ?? _doctor.Cedula;
                _doctor.NumeroDeTelefono = doctor.NumeroDeTelefono ?? _doctor.NumeroDeTelefono;

                _repo.Actualizar(_doctor);
                return Ok(_doctor);
            }
            catch (Exception ex)
            {
                return StatusCode(500,
                    new
                    {
                        Error = "410025",
                        Mensaje = "Error: Cliente no fue procesado",
                        Data = doctor
                    });
            }
        }

        //Eliminar un Doctor
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
