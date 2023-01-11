using Api_Consultorio.Dtos;
using Consultorio.Business.Entidades;
using Consultorio.Business.Interfaces.Repositorios;
using Consultorio.Business.Interfaces.Servicios;
using Consultorio.Business.Modelos;
using Consultorio.Business.Servicios;
using Infraestructura.SQLServer.Contextos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Api_Consultorio.Controllers
{
    [ApiController]
    [Route("doctor")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorServices _doctorServices;
        private readonly ILogger<DoctorController> _logger;

        public DoctorController(IDoctorServices doctorServices, ILogger<DoctorController> logger)
        {

            _logger = logger;
            _doctorServices = doctorServices;
        }

        #region Doctor Post/Get/Put/Delete
        //Agregar un Doctor
        [HttpPost()]
        public ActionResult CrearDoctor([FromBody] DoctorDto doctorDto)
        {
            try
            {
                var result = _doctorServices.AgregarDoctor(
                    doctorDto.Cedula, 
                    doctorDto.Nombre, 
                    doctorDto.Apellido, 
                    doctorDto.NumeroDeTelefono
                    );

                return Ok(result);
            }
            catch (ArgumentException ae)
            {
                _logger.LogError(ae.Message);
                return BadRequest(ae.Message);
            }
            catch (ValidationException ve)
            {
                _logger.LogError(ve.Message);

                return StatusCode(400,
                    new
                    {
                        Error = "410025",
                        Mensaje = "Error: Doctor no fue procesado",
                        Data = ve.Message
                    });
            }
            //catch (Exception ex)
            //{
            //    _logger.LogError(ex.Message);
            //    return StatusCode(500, "Error Interno del Servidor");
            //}
        }





        //Consultar un Doctor
        [HttpGet]
        public ActionResult ConsultarDoctor([FromQuery] DoctorParameters doctorParameters)
        {
            var result = _doctorServices.ConsultarDoctores(doctorParameters);

            var metadata = new
            {
                result.TotalCount,
                result.PageSize,
                result.CurrentPage,
                result.HasNext,
                result.HasPrevious
            };

            Response.Headers.Add("X-Pagination",JsonConvert.SerializeObject(metadata));
            _logger.LogInformation($"Se mostraron {result.TotalCount}  doctores de la base de datos");
            return Ok(result);
        }





        //Consultar un Doctor por Id
        [HttpGet("{Id}")]
        public ActionResult ConsultarDoctor([FromRoute] string id)
        {
            var result = _doctorServices.ConsultarDoctorPorId(id);
            try
            {
                if (result == null)
                {
                    return NotFound("Doctor no encontrado");
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
                        Mensaje = "Error: Doctor no fue procesado",
                        Data = result
                    });
            }
        }

        //Actualizar un Doctor
        [HttpPut("{id}")]
        public ActionResult ActualizarDoctor(string id, [FromBody] ActualizarDoctorDto doctor)
        {
            try
            {
                var result = _doctorServices.ActualizarDoctor(
                    id, 
                    doctor.Cedula, 
                    doctor.Nombre, 
                    doctor.Apellido, 
                    doctor.NumeroDeTelefono
                    );
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
                        Mensaje = "Error: Doctor no fue procesado",
                        Data = doctor
                    });
            }
        }

        //Eliminar un Doctor
        [HttpDelete("{Id}")]
        public ActionResult EliminarDoctor([FromRoute] string id)
        {
            Doctor doctor = _doctorServices.ConsultarDoctorPorId(id);
            try
            {
                _doctorServices.EliminarDoctor(id);
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
                        Mensaje = "Error: Doctor no fue procesado",
                        Data = doctor
                    });
            }
            return Ok(doctor);
        }
        #endregion
    }
}
