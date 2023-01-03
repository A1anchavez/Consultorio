using Api_Consultorio.Modelos;
using Consultorio.Business.Entidades;
using System;

namespace Consultorio.Business.Interfaces.Servicios
{
    public interface IClienteServices
    {
        Cliente AgregarCliente(Cliente cliente);
        Cliente ConsultarClientes(ClienteParameters clienteParameters);
        Cliente ConsultarClientePorId(string id);
        Cliente ActualizarCliente(string id, string nombre, string apellido, string direccion, DateTime? fecha);
        Cliente EliminarCliente();
        Consulta AgregarConsulta(Consulta consulta);


    }
}
