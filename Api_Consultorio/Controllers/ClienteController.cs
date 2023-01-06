using Api_Consultorio.Dtos;
using Api_Consultorio.Modelos;
using Consultorio.Business.Entidades;
using Infraestructura.SQLServer.Contextos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Consultorio.Business.Interfaces.Repositorios;
using Consultorio.Business.Interfaces.Servicios;
using Consultorio.Business.Servicios;

namespace Api_Consultorio.Controllers
{
    [ApiController]
    [Route("cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly ILogger<ClienteController> _logger;
        private readonly IClienteServices _clienteServices;

        public ClienteController(ILogger<ClienteController> logger, IClienteServices clienteServices)
        {
            _logger = logger;
            _clienteServices = clienteServices;
        }


        #region Cliente Post/Get/Put/Delete
        [HttpPost()]
        public ActionResult CrearCliente([FromBody] ClienteDto clienteDto)
        {
            try
            {
                var result = _clienteServices.AgregarCliente(clienteDto.Nombre, clienteDto.Apellido, clienteDto.FechaDeNacimiento, clienteDto.Direccion);
                var result2 = _clienteServices.AgregarUsuario(result.Id, clienteDto.NombreUsuario, clienteDto.Contraseña);
                return Ok(result);
            }
            catch (ValidationException ve)
            {
                _logger.LogError(ve.Message);

                return StatusCode(400,
                    new
                    {
                        Error = "410025",
                        Mensaje = "Error: Cliente no fue procesado",
                        Data = ve.Message
                    });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Error Interno del Servidor");
            }
        }


        //Consultar un Cliente
        [HttpGet]
        public ActionResult ConsultarCliente([FromQuery] ClienteParameters clienteParameters)
        {
            var result = _clienteServices.ConsultarClientes(clienteParameters);

            var metadata = new
            {
                result.TotalCount,
                result.PageSize,
                result.CurrentPage,
                result.HasNext,
                result.HasPrevious
            };

            Response.Headers.Add("X-Paginacion", JsonConvert.SerializeObject(metadata));
            _logger.LogInformation($"Se mostraron {result.TotalCount}  doctores de la base de datos");

            return Ok(result);
        }

        //Consultar un Cliente por Id
        [HttpGet("{Id}")]
        public ActionResult ConsultarCliente([FromRoute] string id)
        {
            var result = _clienteServices.ConsultarClientePorId(id);
            try
            {
                if (result == null)
                {
                    return NotFound("Cliente no encontrado");
                }



                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return StatusCode(500,
                    new
                    {
                        Error = "410025",
                        Mensaje = "Error: Cliente no fue procesado",
                        Data = result
                    });
            }

        }

        //Actualizar un cliente
        [HttpPut("{id}")]
        public ActionResult ActualizarCliente(string id, [FromBody] ActualizarClienteDto cliente)
        {
            try
            {
                var result = _clienteServices.ActualizarCliente(id, cliente.Nombre, cliente.Apellido, cliente.FechaDeNacimiento, cliente.Direccion);
                return Ok(result);
            }
            catch (ValidationException ve)
            {
                _logger.LogError(ve.Message);
                return BadRequest(ve.Message);
            }
            catch (ArgumentException ae)
            {
                _logger.LogError(ae.Message);
                return BadRequest(ae.Message);
            }
            catch (Exception ex)
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

        //Eliminar un cliente
        [HttpDelete("{Id}")]
        public ActionResult EliminarCliente([FromRoute] string id)
        {
            Cliente cliente = _clienteServices.ConsultarClientePorId(id);
            try
            {
                _clienteServices.EliminarCliente(id);
            }
            catch (ValidationException ve)
            {
                _logger.LogError(ve.Message);
                return BadRequest(ve.Message);
            }
            catch (Exception ex)
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
        #endregion



        //ToDo: terminar consultaController
        #region Consulta Post/Get/Put/Delete

        //Agregar una Consulta
        [HttpPost("{idCliente}/consultas")]
        public ActionResult AgregarConsulta([FromRoute] string idCliente, [FromBody] CrearConsultaDto consultaDto)
        {
            try
            {
                var result = _clienteServices.AgregarConsulta(
                    consultaDto.ClienteId,
                    consultaDto.DoctorId,
                    consultaDto.FechaConsulta,
                    consultaDto.Motivo
                    );
                return Ok(result);
            }
            catch (ValidationException ve)
            {
                _logger.LogError(ve.Message);
                return BadRequest(ve.Message);
            }
            catch (ArgumentNullException)
            {
                _logger.LogError("Argumentos invalidos {consulta}", consultaDto);
                return BadRequest("Objeto requerido.");
            }
            catch (ArgumentException ae)
            {
                _logger.LogError(ae.Message);
                return BadRequest(ae.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Error Interno del Servidor");
            }
        }

        //Consultar una consulta jaja
        //[HttpGet]
        //public ActionResult ConsultarConsulta([FromQuery] Consulta consulta)
        //{

        //    return Ok(consulta);
        //}


        //ToDo: confirmar rutas

        //Consultar una consulta por id
        [HttpGet("{idCliente}/consultas/{idConsulta}")]
        public ActionResult ConsultarConsulta([FromRoute] string idCliente)
        {
            var result = _clienteServices.ConsultarConsultaPorId(idCliente);
            try
            {
                if (result == null)
                {
                    return NotFound("Consulta no encontrada");
                }



                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return StatusCode(500,
                    new
                    {
                        Error = "410025",
                        Mensaje = "Error: Consulta no fue procesada",
                        Data = result
                    });
            }
        }


        //Actualizar una Consulta
        [HttpPut("{idCliente}/citas/{idCita}")]
        public IActionResult ActualizarCita(string id, [FromBody] ActualizarConsultaDto consulta)
        {
            try
            {
                var result = _clienteServices.ActualizarConsulta(
                    id,
                    consulta.DoctorId,
                    consulta.FechaDeConsulta,
                    consulta.Motivo);
                return Ok(result);
            }
            catch (ValidationException ve)
            {
                _logger.LogError(ve.Message);
                return BadRequest(ve.Message);
            }
            catch (ArgumentException ae)
            {
                _logger.LogError(ae.Message);
                return BadRequest(ae.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500,
                    new
                    {
                        Error = "410025",
                        Mensaje = "Error: Consulta no fue procesada",
                        Data = consulta
                    });
            }
        }

        //Eliminar una Consulta
        [HttpDelete("{idCliente}/citas/{idCita}")]
        public IActionResult EliminarCita([FromRoute] string id)
        {
            Consulta consulta = _clienteServices.ConsultarConsultaPorId(id);
            try
            {
                _clienteServices.EliminarConsulta(id);
            }
            catch (ValidationException ve)
            {
                _logger.LogError(ve.Message);
                return BadRequest(ve.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500,
                    new
                    {
                        Error = "410025",
                        Mensaje = "Error: Consulta no fue procesada",
                        Data = consulta
                    });
            }
            return Ok(consulta);
        }
        #endregion
        //public dynamic IniciarSesion([FromBody] object optData)
        //{
        //    var result = _clienteServices.IniciarSesion(optData);
        //    //ps a ver que royal
        //}
    }
}
