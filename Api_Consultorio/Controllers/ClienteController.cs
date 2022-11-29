using Consultorio.Business.Entidades;
using Infraestructura.SQLServer.Contextos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;


namespace Api_Consultorio.Controllers
{
    [ApiController]
    [Route("cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly SQLServerContext _context;
        public ClienteController(SQLServerContext context)
        {
            _context = context;
        } 

        [HttpGet]
        [Route("Consultar")]
        public ActionResult consultarCliente()
        {
            var cliente = _context.Clientes.ToList();
            return Ok(cliente);
        }
        [HttpGet("{Id}")]
        public ActionResult ConsultarCliente([FromRoute] string id)
        {
            Cliente cliente = _context.Clientes.Where(x => x.Id == id).FirstOrDefault();
            try
            {
                //return cliente;
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

        }
        [HttpPost()]
        public ActionResult CrearCliente([FromBody] Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();

            return Ok(cliente);
        }

    }
}
