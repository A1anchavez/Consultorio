﻿using Consultorio.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Business.Entidades
{
    public class Cliente : Persona, IEntity
    {
        private readonly string Path = "C:\\Users\\alan.chavez\\Desktop\\Entrenamiento Desarollo\\Residencias Consultorio\\ListaClientes.csv";
        public readonly IRepository<Cliente> repository;
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public string Direccion { get; set; }

        public Cliente(IRepository<Cliente> repo)
        {
            repository = repo;
        }
        public Cliente()
        {

        }
        public Cliente(IRepository<Cliente> repository, string nombre, string apellidos, DateTime fechaDeNacimiento, string? direccion)
        {
            Nombre = nombre;
            Apellidos = apellidos;
            this.repository = repository;
            FechaDeNacimiento = fechaDeNacimiento;
            Direccion = direccion;
        }
        public override string ToString()
        {
            return $"{Id}, {Nombre}, {Apellidos},{FechaDeNacimiento},{Direccion}";
        }
        public void AgregarCliente(Cliente cliente)
        {
            //Todo: Validar datos de entrada
            if (String.IsNullOrEmpty(cliente.Nombre) || String.IsNullOrEmpty(cliente.Apellidos))
            {
                throw new ArgumentException("Las propiedades deben tener un valor. " +
                    "La propiedadad Nombre, Apellidos o Direccion estan vacias");
            }
            //Buscar si existe el cliente en la base de datos
            var result = repository.Consultar().Where(x =>
                            x.Nombre.ToUpper().Equals(cliente.Nombre.ToUpper()) &&
                            x.Apellidos.ToUpper().Equals(cliente.Apellidos.ToUpper())
                         ).ToList();
            if (result.Count != 0)
            {
                throw new ArgumentException("El cliente ya existe");
            }
            repository.Agregar(cliente);
        }
        public List<Cliente> Cargar_Clientes()
        {
            return repository.Consultar();
        }
        public void Guardar(List<Cliente> cliente)
        {
            repository.Guardar(cliente);
        }
        public void Agregar_Cliente()
        {

            Cliente cliente = new Cliente()
            {
                Id = Guid.NewGuid().ToString(),
                Nombre = Nombre,
                Apellidos = Apellidos,
                FechaDeNacimiento = FechaDeNacimiento,
                Direccion = Direccion
            };

            Agregar_Cliente(cliente);

        }
        public void Agregar_Cliente(Cliente cliente)
        {
            this.repository.Agregar(cliente);
        }
    }
}