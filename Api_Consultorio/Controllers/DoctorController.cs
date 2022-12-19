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
        public ActionResult CrearDoctor([FromBody] Doctor doctor)
        {
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
    }
}
