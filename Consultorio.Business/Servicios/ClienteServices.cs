
using Api_Consultorio.Modelos;
using Consultorio.Business.Entidades;
using Consultorio.Business.Interfaces.Repositorios;
using Consultorio.Business.Interfaces.Servicios;
using Consultorio.Business.Modelos;
using Consultorio.Business.Soportes;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Transversal.Loggers;

namespace Consultorio.Business.Servicios
{
    public class ClienteServices : IClienteServices
    {
        private readonly IClienteRepository _repo;
        private readonly IConsultaRepository _consultaRepo;
        private readonly IDoctorRepository _doctorRepo;
        private readonly IUsuarioRepository _UsuarioRepo;

        public ClienteServices(IClienteRepository repo, IConsultaRepository consultaRepo,
        IDoctorRepository doctorRepo, IUsuarioRepository usuarioRepo)
        {
            this._repo = repo;
            _consultaRepo = consultaRepo;
            _doctorRepo = doctorRepo;
            _UsuarioRepo = usuarioRepo;
        }

        #region Cliente
        public Cliente ActualizarCliente(string id, string nombre, string apellido, DateTime? fecha, string direccion)
        {

            var cliente = _repo.ConsultarPorId(id) ?? throw new ValidationException("No se encontro el cliente");
            //_cliente.Nombre = Nombre == null ? _cliente.Nombre : Nombre;
            cliente.Nombre = nombre ?? cliente.Nombre;
            cliente.Apellido = apellido ?? cliente.Apellido;
            cliente.Direccion = direccion ?? cliente.Direccion;
            cliente.FechaDeNacimiento = fecha ?? cliente.FechaDeNacimiento;

            _repo.Actualizar(cliente);
            _repo.GuardarCambios();
            return cliente;
        }

        public Cliente AgregarCliente(string nombre, string apellido, DateTime? fecha, string direccion)
        {
            Cliente cliente = new Cliente()
            {
                Nombre = nombre,
                Apellido = apellido,
                FechaDeNacimiento = fecha,
                Direccion = direccion
            };
            var result = _repo.ConsultarPorExistencia(cliente.Nombre, cliente.Apellido, cliente.FechaDeNacimiento);
            if (!(result is null))
            {
                throw new ValidationException("El cliente ya existe en la base de datos con un Id: " + result.Id);
            }
            _repo.Agregar(cliente);
            _repo.GuardarCambios();
            return cliente;
        }

        public Cliente ConsultarClientePorId(string id)
        {
            var cliente = _repo.Consultar().Where(x => x.Id == id).FirstOrDefault();
            return cliente;

        }

        public PagedList<Cliente> ConsultarClientes(ClienteParameters clienteParameters)
        {
            var cliente = _repo.Consultar(clienteParameters);
            var metadata = new
            {
                cliente.TotalCount,
                cliente.PageSize,
                cliente.CurrentPage,
                cliente.HasNext,
                cliente.HasPrevious
            };
            return cliente;
        }

        public Cliente EliminarCliente(string id)
        {
            Cliente cliente = _repo.ConsultarPorId(id);
            if (cliente == null)
            {
                throw new ValidationException("Cliente no encontrado");
            }
            _repo.Eliminar(cliente);
            return cliente;
        }
        #endregion

        #region Consulta
        public Consulta AgregarConsulta(string clienteId, string doctorId, DateTime? fecha, string? motivo)
        {
            Cliente cliente = _repo.ConsultarPorId(clienteId);
            Doctor doctor = _doctorRepo.ConsultarPorId(doctorId);
            //Validar que el cliente exista
            if (cliente == null)
            {
                throw new ValidationException("El cliente no existe");
            }
            //Validar que el doctor exista
            if (doctor == null)
            {
                throw new ValidationException("El Doctor no existe");
            }

            //Validar que ni el doctor ni el paciente tengan citas en mismo horario
            if (!_doctorRepo.FechaDisponible(doctorId, fecha) ||
                !_repo.FechaDisponible(clienteId, fecha))
                throw new ValidationException("Fecha no disponible, ya esta ocupada");

            Consulta consulta = new Consulta()
            {
                ClienteId = clienteId,
                Cliente = cliente,
                DoctorId = doctorId,
                Doctor = doctor,
                FechaConsulta = fecha.Value,
                Motivo = motivo
            };
            _consultaRepo.Agregar(consulta);
            _consultaRepo.GuardarCambios();

            return consulta;
        }

        public PagedList<Consulta> ConsultarConsulta(ConsultaParameters consultaParameters)
        {
            var consulta = _consultaRepo.Consultar(consultaParameters);
            var metadata = new
            {
                consulta.TotalCount,
                consulta.PageSize,
                consulta.CurrentPage,
                consulta.HasNext,
                consulta.HasPrevious
            };
            return consulta;
        }

        public Consulta ConsultarConsultaPorId(string id)
        {
            var consulta = _consultaRepo.Consultar().Where(x => x.Id == id).FirstOrDefault();
            return consulta;
        }

        public Consulta ActualizarConsulta(string id, string doctorId, DateTime? fecha, string motivo)
        {
            var consulta = _consultaRepo.ConsultarPorId(id) ?? throw new ValidationException("No se encontro la consulta");
            consulta.DoctorId = doctorId ?? consulta.DoctorId;
            consulta.FechaConsulta = fecha ?? consulta.FechaConsulta;
            consulta.Motivo = motivo ?? consulta.Motivo;

            _consultaRepo.Actualizar(consulta);
            _consultaRepo.GuardarCambios();
            return consulta;
        }

        public Consulta EliminarConsulta(string id)
        {
            Consulta consulta = _consultaRepo.ConsultarPorId(id);
            if (consulta == null)
            {
                throw new ValidationException("Consulta no encontrado");
            }
            _consultaRepo.Eliminar(consulta);
            return consulta;
        }
        #endregion


        public Usuario AgregarUsuario(string id, string nombre, string contraseña)
        {
            Usuario usuario = new Usuario(id, nombre, contraseña, "Cliente");
            _UsuarioRepo.Agregar(usuario);
            _UsuarioRepo.GuardarCambios();
            return usuario;
        }
        public Usuario IniciarSesion(object optData)
        {
            var data = JsonConvert.DeserializeObject<dynamic>(optData.ToString());
            string user = data.usuario.ToString();
            string contraseña = data.contraseña.ToString();

            Usuario usuario = _UsuarioRepo.Consultar().Where(x => x.NombreUsuario == user
            && x.Contraseña == contraseña).FirstOrDefault();
            if (usuario == null)
            {
                throw new ArgumentException("Nombre de usuario o contraseña son incorrectos");
            }
            return usuario;
        }
        public bool ValidarToken(ClaimsIdentity identity)
        {
                if (identity.Claims.Count() == 0)
                {
                    throw new ArgumentException("Token invalido");
                }
                var id = identity.Claims.FirstOrDefault(x => x.Type == "id").Value;

                Usuario usuario = _UsuarioRepo.Consultar().Where(x => x.Id == id).FirstOrDefault();

                if (usuario == null || usuario.Rol != "Cliente")
                {
                    throw new ArgumentException("Acceso restringido");
                }
            return true;
            
        }
    }
}
