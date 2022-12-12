using Infraestructura.SQLServer.Contextos;
using Microsoft.AspNetCore.Mvc;

namespace Api_Consultorio.Controllers
{
    [ApiController]
    [Route("doctor")]
    public class DoctorController: ControllerBase
    {
        private readonly SQLServerContext _context;
        public DoctorController(SQLServerContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Consultar")]
        public ActionResult consultarDoctor()
        {
            var doctor = _context.Doctores.ToList();
            return Ok(doctor);
        }
    }
}
