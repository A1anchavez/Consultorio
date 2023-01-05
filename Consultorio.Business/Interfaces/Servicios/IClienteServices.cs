﻿using Api_Consultorio.Modelos;
using Consultorio.Business.Entidades;
using Consultorio.Business.Modelos;
using Consultorio.Business.Soportes;
using System;

namespace Consultorio.Business.Interfaces.Servicios
{
    public interface IClienteServices
    {
        Cliente AgregarCliente(string nombre, string apellido, DateTime? fecha, string direccion);
        PagedList<Cliente> ConsultarClientes(ClienteParameters clienteParameters);
        //Cliente ConsultarClientes(ClienteParameters clienteParameters);
        Cliente ConsultarClientePorId(string id);
        Cliente ActualizarCliente(string id, string nombre, string apellido, DateTime? fecha, string direccion);
        Cliente EliminarCliente(string id);
        Consulta AgregarConsulta(string clienteId, string doctorId, DateTime? fecha, string? motivo);


    }
}