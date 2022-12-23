using Api_Consultorio.Dtos;
using Api_Consultorio.Modelos;
using Consultorio.Business.Entidades;
using Consultorio.Business.Interfaces.Repositorios;
using Consultorio.Business.Interfaces.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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

        public Cliente ActualizarCliente(string id,string nombre, string apellido, string direccion, DateTime? fecha)
        {

            var cliente = _repo.ConsultarPorId(id) ?? throw new ValidationException("No se encontro el cliente");
            //_cliente.Nombre = Nombre == null ? _cliente.Nombre : Nombre;
            cliente.Nombre = nombre ?? cliente.Nombre;
            cliente.Apellido = apellido ?? cliente.Apellido;
            cliente.Direccion = direccion ?? cliente.Direccion;
            cliente.FechaDeNacimiento = fecha ?? cliente.FechaDeNacimiento;

            _repo.GuardarCambios();
            

            return cliente;
        }

        public Cliente AgregarCliente(string nombre, string apellido, string direccion, DateTime fecha)
        {
            //! Validar si el cliente existe
            if (!(_repo.ConsultarporNombre(nombre) is null))
            {
                throw new ValidationException("El cliente ya existe en la base de datos");
            }

            //Crear un nuevo Cliente
            var cte = new Cliente()
            {
                Nombre=nombre,
                Apellido=apellido,
                Direccion=direccion,
                FechaDeNacimiento=fecha
            };
            //Guardar Cambios
            cte.AgregarCliente(cte);
            _repo.GuardarCambios();
            return cte;
        }

        public Consulta AgregarConsulta(string clienteId, string doctorId, DateTime fechaConsulta, string motivo = "")
        {
            //Validar que el cliente exista
            if (_repo.ConsultarPorId(clienteId) == null)
            {
                throw new ValidationException("El cliente no existe");
            }
            //Validar que el doctor exista
            if (_doctorRepo.ConsultarPorId(doctorId) == null)
            {
                throw new ValidationException("El Doctor no existe");
            }

            //Validar que ni el doctor ni el paciente tengan citas en mismo horario
            if (_doctorRepo.FechaDisponible(doctorId, fechaConsulta) &&
                _repo.FechaDisponible(clienteId, fechaConsulta))
                throw new ValidationException("Fecha no disponible");

            var consulta = new Consulta(
                clienteId,
                doctorId,
                fechaConsulta,
                motivo
            );


            // cita.Update(doctorId,fechaConsulta);// = DateTime.Now.AddDays(-1);


            _consultaRepo.Agregar(consulta);
            _consultaRepo.GuardarCambios();

            return consulta;
        }

        public Cliente ConsultarClientePorId(string id)
        {
            var cliente = _repo.Consultar().Where(x => x.Id == id).FirstOrDefault();
            return cliente;

        }

        public Cliente ConsultarClientes(ClienteParameters clienteParameters)
        {
            var cliente = _repo.Consultar(clienteParameters);
            return (Cliente)cliente;
        }

        public Cliente EliminarCliente()
        {
            throw new NotImplementedException();
        }
    }
}
