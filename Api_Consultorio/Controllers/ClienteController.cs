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
                Cliente cliente = new Cliente()
                {
                    //Id = clienteDto.Id,
                    Nombre = clienteDto.Nombre,
                    Apellido = clienteDto.Apellido,
                    FechaDeNacimiento = clienteDto.FechaDeNacimiento,
                    Direccion = clienteDto.Direccion
                };

                _clienteServices.AgregarCliente(cliente);

                return Ok(cliente);
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
        public ActionResult consultarCliente([FromQuery] ClienteParameters clienteParameters)
        {
            var result = _clienteServices.ConsultarClientes(clienteParameters);
            //var metadata = new
            //{
            //    cliente.TotalCount,
            //    cliente.PageSize,
            //    cliente.CurrentPage,
            //    cliente.HasNext,
            //    cliente.HasPrevious
            //};

            //Response.Headers.Add("X-Paginacion", JsonConvert.SerializeObject(metadata));
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
            // ToDo: checar actualizar
            try
            {
                var result = _clienteServices.ActualizarCliente(id, cliente.Nombre, cliente.Apellido, cliente.Direccion, cliente.FechaDeNacimiento);
                return Ok(result);
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
        #endregion

        #region Consulta Post/Get/Put/Delete

        //Agregar una Consulta
        [HttpPost("{idCliente}/consultas")]
        public ActionResult AgregarConsulta([FromRoute] string idCliente, [FromBody] CrearConsultaDto consultaDto)
        {
            try
            {
                
                //Cliente cliente = _clienteServices.ConsultarClientePorId(idCliente);
                //Doctor doctor = _doctorServices.ConsultarDoctorPorId(consultaDto.DoctorId);
                Consulta consulta2 = new Consulta()
                {
                    ClienteId = consultaDto.ClienteId,
                   // Cliente = cliente,
                    DoctorId = consultaDto.DoctorId,
                   // Doctor = doctor,
                    FechaConsulta = consultaDto.FechaConsulta,
                    Motivo = consultaDto.Motivo
                };
                var result = _clienteServices.AgregarConsulta(consulta2);
                //--------
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
        //    //var consulta2 = _repo.Consultar(consulta);
        //    //return (consulta2);
        //    return Ok(consulta);
        //}

        ////Actualizar una Consulta
        //[HttpPut("{idCliente}/citas/{idCita}")]
        //public IActionResult ActualizarCita()
        //{
        //    return Ok();
        //}

        ////Eliminar una Consulta
        //[HttpDelete("{idCliente}/citas/{idCita}")]
        //public IActionResult EliminarCita()
        //{
        //    return Ok();
        //}
        #endregion
    }
}
