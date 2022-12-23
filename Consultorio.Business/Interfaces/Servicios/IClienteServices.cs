using Api_Consultorio.Modelos;
using Consultorio.Business.Entidades;
using System;

namespace Consultorio.Business.Interfaces.Servicios
{
    public interface IClienteServices
    {
        Cliente AgregarCliente(string nombre, string apellido, string direccion, DateTime fecha);
        Cliente ConsultarClientes();
        Cliente ConsultarClientePorId();
        Cliente ActualizarCliente(string id, string nombre, string apellido, string direccion, DateTime? fecha);
        Cliente EliminarCliente();
        Consulta AgregarConsulta(string clienteId, string doctorId, DateTime fechaConsulta, string motivo = "");


    }
}
