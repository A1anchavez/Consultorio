
using Api_Consultorio.Modelos;
using Consultorio.Business.Entidades;
using Consultorio.Business.Interfaces.Repositorios;
using Consultorio.Business.Interfaces.Servicios;
using Consultorio.Business.Soportes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


namespace Consultorio.Business.Servicios
{
    public class ClienteServices : IClienteServices
    {
        private readonly IClienteRepository _repo;
        private readonly IConsultaRepository _consultaRepo;
        private readonly IDoctorRepository _doctorRepo;

        public ClienteServices(IClienteRepository repo, IConsultaRepository consultaRepo,
        IDoctorRepository doctorRepo)
        {
            this._repo = repo;
            _consultaRepo = consultaRepo;
            _doctorRepo = doctorRepo;
        }

        public Cliente ActualizarCliente(string id,string nombre, string apellido, DateTime? fecha, string direccion)
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
                    throw new ValidationException("El cliente ya existe en la base de datos con un Id: "+result.Id);
                }
                _repo.Agregar(cliente);
                _repo.GuardarCambios();
                return cliente;
        }

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
            if (_doctorRepo.FechaDisponible(doctorId, fecha) &&
                _repo.FechaDisponible(clienteId, fecha))
                throw new ValidationException("Fecha no disponible");

            Consulta consulta = new Consulta()
            {
                ClienteId = clienteId,
                Cliente = cliente,
                DoctorId = doctorId,
                Doctor = doctor,
                FechaConsulta=fecha.Value,
                Motivo=motivo
            };
            _consultaRepo.Agregar(consulta);
            _consultaRepo.GuardarCambios();

            return consulta;
        }

        public Cliente ConsultarClientePorId(string id)
        {
            var cliente = _repo.Consultar().Where(x => x.Id == id).FirstOrDefault();
            return cliente;

        }

        
        //ClienteParameters clienteParameters
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
    }
}
