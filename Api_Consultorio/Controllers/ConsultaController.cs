using Microsoft.AspNetCore.Mvc;
using Consultorio.Business.Entidades;
using Infraestructura.SQLServer.Contextos;
using Infraestructura.SQLServer.Repositorios;
using Consultorio.Business.Interfaces;
using Api_Consultorio.Dtos;

namespace Api_Consultorio.Controllers
{
    [ApiController]
    [Route("consulta")]
    public class ConsultaController : ControllerBase
    {
        private readonly IConsultaRepository _repo;
        private readonly ILogger<ConsultaController> logger;

        public ConsultaController(IConsultaRepository repo, ILogger<ConsultaController> logger)
        {
            _repo = repo;
            this.logger = logger;
        }

        //Agregar una consulta
        [HttpPost()]
        public ActionResult CrearConsulta([FromBody] ConsultaDto consultaDto)
        {
            
            var consulta = new Consulta()
            {
                Id = consultaDto.Id,
                ClienteId = consultaDto.ClienteId,
                Cliente =consultaDto.Cliente,
                DoctorId = consultaDto.DoctorId,
                Doctor= consultaDto.Doctor,
                FechaConsulta = consultaDto.FechaConsulta,
                Motivo = consultaDto.Motivo
            };
            _repo.Agregar(consulta);
            _repo.GuardarCambios();
            return Ok(consulta);
        }
    }
}
