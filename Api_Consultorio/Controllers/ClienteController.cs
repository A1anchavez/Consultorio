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
using Consultorio.Business.Modelos;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Api_Consultorio.Controllers
{
    [ApiController]
    [Route("cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly ILogger<ClienteController> _logger;
        private readonly IClienteServices _clienteServices;
        private readonly IConfiguration _configuration;

        public ClienteController(ILogger<ClienteController> logger, IClienteServices clienteServices, IConfiguration configuration)
        {
            _logger = logger;
            _clienteServices = clienteServices;
            _configuration = configuration;
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
            _logger.LogInformation($"Se mostraron {result.TotalCount}  Clientes de la base de datos");

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
        [HttpPost("{idCliente}/consulta")]
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
        [HttpGet("{idCliente}/consulta")]
        public ActionResult ConsultarConsulta([FromQuery] ConsultaParameters consultaParameters)
        {
            var result = _clienteServices.ConsultarConsulta(consultaParameters);

            var response = new List<ConsultaResponseDto>();
            foreach (var c in result)
            {
                var item = new ConsultaResponseDto()
                {
                    IdCliente = c.ClienteId,
                    IdDoctor = c.DoctorId,
                    FechaConsulta = c.FechaConsulta,
                    Motivo = c.Motivo
                };
                response.Add(item);
            }

            var metadata = new
            {
                result.TotalCount,
                result.PageSize,
                result.CurrentPage,
                result.HasNext,
                result.HasPrevious
            };

            Response.Headers.Add("X-Paginacion", JsonConvert.SerializeObject(metadata));
            _logger.LogInformation($"Se mostraron {result.TotalCount}  Consultas de la base de datos");

            return Ok(response);
        }




        //ToDo: Revisar ruta de consultar por id, actualizar y eliminar consultas

        //Consultar una consulta por id
        [HttpGet("{idCliente}/consulta/{idConsulta}")]
        public ActionResult ConsultarConsulta([FromRoute] string idCliente, [FromRoute] string idConsulta)
        {
            
            
            var result = _clienteServices.ConsultarConsultaPorId(idConsulta);
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                var token = _clienteServices.ValidarToken(identity);
                if (token != true)
                {
                    throw new ArgumentException("Acceso restringido");
                }
                if (result == null)
                {
                    return NotFound("Consulta no encontrada");
                }



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
        [HttpPut("{idCliente}/consulta/{idCita}")]
        public IActionResult ActualizarConsulta([FromRoute]string id, [FromRoute] string idConsulta, [FromBody] ActualizarConsultaDto consulta)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                var token = _clienteServices.ValidarToken(identity);
                if (token != true)
                {
                    throw new ArgumentException("Acceso restringido");
                }

                var result = _clienteServices.ActualizarConsulta(
                    idConsulta,
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
        [HttpDelete("{idCliente}/consulta/{idCita}")]
        public IActionResult EliminarCita([FromRoute] string idCliente, [FromRoute] string idConsulta)
        {
            Consulta consulta = _clienteServices.ConsultarConsultaPorId(idConsulta);
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                var token = _clienteServices.ValidarToken(identity);
                if (token != true)
                {
                    throw new ArgumentException("Acceso restringido");
                }

                _clienteServices.EliminarConsulta(idConsulta);
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
            return Ok(consulta);
        }
        #endregion

        #region Usuario Metodos
        [HttpPost("inicioSesion")]
        public dynamic IniciarSesion([FromBody] object optData)
        {
            try
            {


                var result = _clienteServices.IniciarSesion(optData);
                var jwt = _configuration.GetSection("Jwt").Get<Jwt>();

                var claims = new[]
                {
                new Claim(JwtRegisteredClaimNames.Sub, jwt.subject),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("id", result.Id),
                new Claim("usuario", result.NombreUsuario)
            };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    jwt.Issuer,
                    jwt.Audience,
                    claims,
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signIn
                    );
                return Ok(new JwtSecurityTokenHandler().WriteToken(token));
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
                        Mensaje = "Error: Consulta no fue procesada"
                    });
            }
            
            
            //ps a ver que royal
        }
        //wA desayunar

        #endregion
    }
}
