using Api_Consultorio.Dtos;
using Api_Consultorio.Modelos;
using Consultorio.Business.Entidades;
using Consultorio.Business.Interfaces;
using Infraestructura.SQLServer.Contextos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Api_Consultorio.Controllers
{
    [ApiController]
    [Route("cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _repo;
        private readonly ILogger<ClienteController> logger;

        public ClienteController(IClienteRepository repo, ILogger<ClienteController> logger)
        {
            _repo = repo;
            this.logger = logger;
        }

        [HttpPost()]
        public ActionResult CrearCliente([FromBody] ClienteDto clienteDto)
        {
            var cliente = new Cliente()
            {
                Id = clienteDto.Id,
                Nombre = clienteDto.Nombre,
                Apellido = clienteDto.Apellido,
                FechaDeNacimiento = clienteDto.FechaDeNacimiento,
                Direccion = clienteDto.Direccion
            };
            _repo.Agregar(cliente);
            _repo.GuardarCambios();

            return Ok(cliente);
        }



        [HttpGet]
        public ActionResult consultarCliente([FromQuery] ClienteParameters clienteParameters)
        {
            var cliente = _repo.Consultar(clienteParameters);

            //var metadata = new
            //{
            //    cliente.TotalCount,
            //    cliente.PageSize,
            //    cliente.CurrentPage,
            //    cliente.HasNext,
            //    cliente.HasPrevious
            //};

            //Response.Headers.Add("X-Paginacion", JsonConvert.SerializeObject(metadata));
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
        [HttpPut("{id}")]
        public ActionResult ActualizarCliente(string id,[FromBody] ActualizarClienteDto cliente)
        {
            var _cliente = _repo.ConsultarPorId(id);
            try
            {
                //return consulta;
                if (_cliente == null)
                {
                    return NotFound("Cliente no encontrado");
                }

                _cliente.Nombre = cliente.Nombre ?? _cliente.Nombre;
                _cliente.Apellido = cliente.Apellido ?? _cliente.Apellido;
                _cliente.FechaDeNacimiento = cliente.FechaDeNacimiento ?? _cliente.FechaDeNacimiento;
                _cliente.Direccion = cliente.Direccion ?? _cliente.Direccion;

                _repo.Actualizar(_cliente);
                return Ok(_cliente);
            }
            catch(Exception ex)
            {
                return StatusCode(500,
                    new
                    {
                        Error = "410025",
                        Mensaje = "Error: Cliente no fue procesado",
                        Data = cliente
                    });
            }

            //return Ok(_cliente);
        }

        //Eliminar una consulta
        [HttpDelete("{Id}")]
        public ActionResult EliminarCliente([FromRoute] string id)
        {
            Cliente cliente = _repo.ConsultarPorId(id);
            try
            {
                //return consulta;
                if (cliente == null)
                {
                    return NotFound("Cliente no encontrado");
                }
                _repo.Eliminar(id, cliente);
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
    }

}
