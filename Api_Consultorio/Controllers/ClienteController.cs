using Consultorio.Business.Entidades;
using Consultorio.Business.Interfaces;
using Infraestructura.SQLServer.Contextos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;


namespace Api_Consultorio.Controllers
{
    [ApiController]
    [Route("cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _repo;
        private readonly ILogger<ClienteController> logger;

        public ClienteController(IClienteRepository repo, ILogger<ClienteController> logger )
        {
            _repo = repo;
            this.logger = logger;
        }

        [HttpPost()]
        public ActionResult CrearCliente([FromBody] Cliente cliente)
        {
            _repo.Agregar(cliente);
            _repo.GuardarCambios();

            return Ok(cliente);
        }

        [HttpGet]
        [Route("Consultar")]
        public ActionResult consultarCliente()
        {
            var cliente = _repo.Consultar();
            return Ok(cliente);
        }
        [HttpGet("{Id}")]
        public ActionResult ConsultarCliente([FromRoute] string id)
        {
            Cliente cliente = _repo.Consultar().Where(x => x.Id == id).FirstOrDefault();//Todo: Refactorizar
            try
            {
                //return cliente;
                if (cliente == null)
                {
                    return NotFound("Cliente no encontrado");
                }



                return Ok(cliente);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);

                return StatusCode(500,
                    new
                    {
                        Error = "410025",
                        Mensaje = "Error: Cliente no fue procesado",
                        Data = cliente
                    });
            }

        }

        //Actualizar una consulta
        [HttpPut("{Id}")]
        [Route("Actualizar")]
        public ActionResult ActualizarCliente([FromBody] string id)
        {
            Cliente cliente = _repo.ConsultarPorId(id);
            try
            {
                //return consulta;
                if (cliente == null)
                {
                    return NotFound("Cliente no encontrado");
                }

                return Ok(cliente);
            }
            catch
            {
                return StatusCode(500,
                    new
                    {
                        Error = "410025",
                        Mensaje = "Error: Cliente no fue procesado",
                        Data = cliente
                    });
            }
            
            return Ok(cliente);
        }

        //Eliminar una consulta
        [HttpDelete("{Id}")]
        [Route("Eliminar")]
        public ActionResult EliminarCliente([FromBody] string id)
        {
            Cliente cliente = _repo.ConsultarPorId(id);
            try
            {
                //return consulta;
                if (cliente == null)
                {
                    return NotFound("Cliente no encontrado");
                }
            }
            catch
            {
                return StatusCode(500,
                    new
                    {
                        Error = "410025",
                        Mensaje = "Error: Cliente no fue procesado",
                        Data = cliente
                    });
            }
            //Todo: Crear metodo Eliminar
            /*
             * Crear el metodo en el IRepository
             * Crear la funcionalida en Repository
             * Guardar Cambios
             * */
            //_context.Remove(cliente);
            return Ok(cliente);
        }
    }

}
