using Api_Consultorio.Contexto;
using Api_Consultorio.Dtos;
using Consultorio.Business.Entidades;
using Consultorio.Business.Interfaces.Servicios;
using Consultorio.Business.Modelos;
using Consultorio.Business.Soportes;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Api_Consultorio.Dapper.Servicios
{
    public class DoctorDapperService : IDoctorServices
    {
        private readonly DapperContext _context;

        public DoctorDapperService(DapperContext context)
        {
            _context = context;
        }

        public Doctor ActualizarDoctor(string id, string cedula, string nombre, string apellido, string numCel)
        {
            var _doctor = ConsultarDoctorPorId(id);
            if (_doctor == null)
            {
                throw new ValidationException("Doctor no encontrado");
            }
            var doctor = new Doctor()
            {
                Cedula = cedula,
                Nombre = nombre,
                Apellido = apellido,
                NumeroDeTelefono = numCel
            };
            var query = "UPDATE cat.Doctores SET "
                + "cedulaDoctor=@cedulaDoctor,nombreDoctor=@nombreDoctor,numeroTelefonoDoctor=@numeroTelefonoDoctor,apellidoDoctor=@apellidoDoctor "
                + "WHERE Id=@id";

            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.String);
            parameters.Add("cedulaDoctor", doctor.Cedula, DbType.Int64);
            parameters.Add("nombreDoctor", doctor.Nombre, DbType.String);
            parameters.Add("apellidoDoctor", doctor.Apellido, DbType.String);
            parameters.Add("numeroTelefonoDoctor", doctor.NumeroDeTelefono, DbType.Int64);


            using (var connection = _context.CreateConnection())
            {
                connection.QuerySingle(query, parameters);
                return doctor;
            }
        }

        public Doctor AgregarDoctor(string cedula, string nombre, string apellido, string numCel)
        {
            var doctor = new Doctor()
            {
                Cedula = cedula,
                Nombre = nombre,
                Apellido = apellido,
                NumeroDeTelefono = numCel
            };
            var query = "INSERT INTO cat.Doctores (Id,cedulaDoctor,nombreDoctor,apellidoDoctor,numeroTelefonoDoctor) " +
                "VALUES (@Id,@cedulaDoctor,@nombreDoctor,@numeroTelefonoDoctor,@apellidoDoctor)";
            
            var parameters = new DynamicParameters();
            parameters.Add("Id", doctor.Id, DbType.String);
            parameters.Add("cedulaDoctor", doctor.Cedula, DbType.Int64);
            parameters.Add("nombreDoctor", doctor.Nombre, DbType.String);
            parameters.Add("apellidoDoctor", doctor.Apellido, DbType.String);
            parameters.Add("numeroTelefonoDoctor", doctor.NumeroDeTelefono, DbType.Int64);


            using (var connection = _context.CreateConnection())
            {
                var id = connection.Execute(query,parameters);
                return doctor;
            }


        }

        public IEnumerable<Doctor> ConsultarDoctores()
        {
            var query = "SELECT * FROM cat.Doctores";
            using (var connection = _context.CreateConnection())
            {
                var companies = connection.Query<Doctor>(query);

                return companies.ToList();
            }
        }

        public Doctor ConsultarDoctorPorId(string id)
        {
            var query = "SELECT Id,CedulaDoctor,NombreDoctor,ApellidoDoctor,NumeroTelefonoDoctor FROM cat.Doctores WHERE Id=@Id";
            using (var connection = _context.CreateConnection())
            {
                var doctor = connection.QuerySingleOrDefault<Doctor>(query, new { id });

                return doctor;
            }
        }

        public Doctor EliminarDoctor(string id)
        {
            var doctor = ConsultarDoctorPorId(id);
            if (doctor == null)
            {
                throw new ValidationException("Doctor no encontrado");
            }
            var query = "DELETE FROM cat.Doctores WHERE Id = @Id";

            using (var connection = _context.CreateConnection())
            {
                var _doctor = connection.Execute(query, new { id });
                return doctor;
            }
        }
    }
}