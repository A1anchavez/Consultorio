using Api_Consultorio.Contexto;
using Api_Consultorio.Modelos;
using Consultorio.Business.Entidades;
using Consultorio.Business.Interfaces.Servicios;
using Consultorio.Business.Modelos;
using Consultorio.Business.Soportes;
using System.Security.Claims;

namespace Api_Consultorio.Dapper.Servicios
{
    public class ClienteDapperService : IClienteServices
    {
        private readonly DapperContext _context;

        public ClienteDapperService(DapperContext context)
        {
            _context = context;
        }

        public Cliente ActualizarCliente(string id, string nombre, string apellido, DateTime? fecha, string direccion)
        {
            throw new NotImplementedException();
        }

        public Consulta ActualizarConsulta(string id, string doctorId, DateTime? fecha, string? motivo)
        {
            throw new NotImplementedException();
        }

        public Doctor ActualizarDoctor(string id, string cedula, string nombre, string apellido, string numCel)
        {
            throw new NotImplementedException();
        }

        public Cliente AgregarCliente(string nombre, string apellido, DateTime? fecha, string direccion)
        {
            throw new NotImplementedException();
        }

        public Consulta AgregarConsulta(string clienteId, string doctorId, DateTime? fecha, string? motivo)
        {
            throw new NotImplementedException();
        }

        public Doctor AgregarDoctor(string cedula, string nombre, string apellido, string numCel)
        {
            throw new NotImplementedException();
        }

        public Usuario AgregarUsuario(string id, string nombre, string contraseña)
        {
            throw new NotImplementedException();
        }

        public Cliente ConsultarClientePorId(string id)
        {
            throw new NotImplementedException();
        }

        public PagedList<Cliente> ConsultarClientes(ClienteParameters clienteParameters)
        {
            throw new NotImplementedException();
        }

        public PagedList<Consulta> ConsultarConsulta(ConsultaParameters consultaParameters)
        {
            throw new NotImplementedException();
        }

        public Consulta ConsultarConsultaPorId(string id)
        {
            throw new NotImplementedException();
        }

        public PagedList<Doctor> ConsultarDoctores(DoctorParameters doctorParameters)
        {
            throw new NotImplementedException();
        }

        public Doctor ConsultarDoctorPorId(string id)
        {
            throw new NotImplementedException();
        }

        public Cliente EliminarCliente(string id)
        {
            throw new NotImplementedException();
        }

        public Consulta EliminarConsulta(string id)
        {
            throw new NotImplementedException();
        }

        public Doctor EliminarDoctor(string id)
        {
            throw new NotImplementedException();
        }

        public Usuario IniciarSesion(object optData)
        {
            throw new NotImplementedException();
        }

        public bool ValidarToken(ClaimsIdentity identity)
        {
            throw new NotImplementedException();
        }
    }
}
