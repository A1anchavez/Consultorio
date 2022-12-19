using Consultorio.Business.Interfaces;
using Infraestructura.SQLServer.Contextos;
using Microsoft.AspNetCore.Mvc;

namespace Api_Consultorio.Controllers
{
    [ApiController]
    [Route("doctor")]
    public class DoctorController: ControllerBase
    {
        private readonly IClienteRepository _repo;
        private readonly ILogger<ClienteController> logger;

        public DoctorController(IClienteRepository repo, ILogger<ClienteController> logger)
        {
            _repo = repo;
            this.logger = logger;
        }
    }
}
