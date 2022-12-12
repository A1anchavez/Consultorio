using Microsoft.AspNetCore.Mvc;
using Consultorio.Business.Entidades;
using Infraestructura.SQLServer.Contextos;


namespace Api_Consultorio.Controllers
{
    [ApiController]
    [Route("consulta")]
    public class ConsultaController: ControllerBase
    {
        private readonly SQLServerContext _context;
        public ConsultaController(SQLServerContext context)
        {
            _context = context;
        }

        //Agregar una consulta
        [HttpPost()]
        [Route("Agregar")]
        public ActionResult CrearConsulta([FromBody] Consulta consulta)
        {
            _context.Consultas.Add(consulta);
            _context.SaveChanges();

            return Ok(consulta);
        }

        //Hacer una consulta a las consultas jaja
        [HttpGet]
        [Route("Consultar")]
        public ActionResult consultarConsulta()
        {
            var consulta = _context.Consultas.ToList();
            return Ok(consulta);
        }
        [HttpGet("{Id}")]//Consultar mediante Id
        public ActionResult ConsultarConsulta([FromRoute] string id)
        {
            Consulta consulta = _context.Consultas.Where(x => x.Id == id).FirstOrDefault();
            try
            {
                //return consulta;
                if (consulta == null)
                {
                    return NotFound("Cliente no encontrado");
                }

                return Ok(consulta);
            }
            catch
            {
                return StatusCode(500,
                    new
                    {
                        Error = "410025",
                        Mensaje = "Error: Cliente no fue procesado",
                        Data = consulta
                    });
            }

        }


        //Actualizar una consulta
        [HttpPut("{Id}")]
        [Route("Actualizar")]
        public ActionResult ActualizarConsulta([FromBody] string id)
        {
            Consulta consulta = _context.Consultas.Where(x => x.Id == id).FirstOrDefault();
            try
            {
                //return consulta;
                if (consulta == null)
                {
                    return NotFound("Cliente no encontrado");
                }

                return Ok(consulta);
            }
            catch
            {
                return StatusCode(500,
                    new
                    {
                        Error = "410025",
                        Mensaje = "Error: Cliente no fue procesado",
                        Data = consulta
                    });
            }
            _context.Update(consulta);
            return Ok(consulta);
        }

        //Eliminar una consulta
        [HttpDelete("{Id}")]
        [Route("Eliminar")]
        public ActionResult EliminarConsulta([FromBody] string id)
        {
            Consulta consulta = _context.Consultas.Where(x => x.Id == id).FirstOrDefault();
            try
            {
                //return consulta;
                if (consulta == null)
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
                        Data = consulta
                    });
            }
            _context.Remove(consulta);
            return Ok(consulta);
        }
    }
}
