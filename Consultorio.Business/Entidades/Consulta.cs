using Consultorio.Business.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transversal.Guards;

namespace Consultorio.Business.Entidades
{
    public class Consulta: IEntity
    {
        //private readonly string Path = "C:\\Users\\alan.chavez\\Desktop\\Entrenamiento Desarollo\\Residencias Consultorio\\ListaConsultas.csv";
        //private readonly string Path_Doctor = "C:\\Users\\alan.chavez\\Desktop\\Entrenamiento Desarollo\\Residencias Consultorio\\ListaDoctores.csv";
        //private readonly string Path_Cliente = "C:\\Users\\alan.chavez\\Desktop\\Entrenamiento Desarollo\\Residencias Consultorio\\ListaClientes.csv";

        ////////////
        public readonly IRepository<Consulta> repository;

        public string Id { get; set; }
        public string ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public string DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        //////////
        
      
        public DateTime FechaConsulta { get; set; }//Formato Pascal

        public string Motivo { get; set; }

        public Consulta()
        {
            Id ??= Guid.NewGuid().ToString();
        }

        public Consulta(IRepository<Consulta> repository, string doctorId, string clienteId, DateTime fecha_consulta, string motivo=""):this()
        {
            this.repository = repository;
            ClienteId = clienteId;
            DoctorId = doctorId;
            FechaConsulta = fecha_consulta.HourBetween(8,19).LaborDays().AfterNow();
            Motivo = motivo;
        }
        public override string ToString()
        {
            return $"{Cliente.Id}, {Cliente.Nombre}, {FechaConsulta},{Motivo}";
        }


        public void AgregarConsulta()
        {
            var consultas = repository.Consultar();/*.Where(x =>
            x.ClienteId == this.ClienteId &&
            x.FechaConsulta == this.FechaConsulta);*/ 
            //Consulta consulta = new Consulta()
            //{
            //    nomDoctor = nomDoctor,
            //    nomCliente = nomCliente,
            //    fechaConsulta = fechaConsulta,
            //    Motivo = Motivo
            //};

            AgregarConsulta(this, consultas);
        }

        public void AgregarConsulta(Consulta consulta /*Esto si no sirve quitar:*/, List<Consulta> ListaConsultas)
        {

            if (string.IsNullOrEmpty(Doctor.Nombre) || string.IsNullOrEmpty(Cliente.Nombre))
            {
                throw new ArgumentException("Las propiedades deben tener un valor. " +
                    "La propiedadad Nombre de el Doctor o Nombre de el Cliente estan vacias");
            }

            //Metodo de validacion

            var resultado = ListaConsultas.Where(x =>
            x.ClienteId == consulta.ClienteId &&
            x.FechaConsulta == consulta.FechaConsulta);

            if(resultado.Any())
                throw new ValidationException("El cliente seleccionado ya cuenta con una consulta asignada para ese dia");





            ListaConsultas.Add(consulta);
            repository.GuardarCambios();

            /** Persistir Elemento en un archivo **/
            //using (StreamWriter strWriter = new StreamWriter(Path, true))
            //{
            //    strWriter.WriteLine(consulta.ToString());
            //    strWriter.Close();
            //}
        }


        public List<Consulta> CargarConsultas()
        {
            //List<Consulta> listaConsultas = new();

            //if (File.Exists(Path))
            //{
            //    /*Leer archivo*/
            //    using (StreamReader strReader = new StreamReader(Path))
            //    {
            //        string ln = string.Empty;

            //        while ((ln = strReader.ReadLine()) != null)
            //        {
            //            string[] campos = ln.Split(",");

            //            Consulta consulta = new()
            //            {
            //                nomDoctor = campos[0],
            //                nomCliente = campos[1],
            //                fechaConsulta = DateTime.Parse(campos[2]),
            //                Motivo = campos[3]
            //            };
            //            listaConsultas.Add(consulta);
            //        }
            //    }
            //}
            return repository.Consultar();
        }

        public void GuardarListaConsultas(List<Consulta> ListaConsultas)
        {
            //foreach (Consulta consulta in ListaConsultas)
            //{
            //    using (StreamWriter strWriter = new StreamWriter(Path, true))
            //    {
            //        strWriter.WriteLine(consulta.ToString());
            //        strWriter.Close();
            //    }

            //}

            repository.Guardar(ListaConsultas);
        }

        #region cargar doctores y clientes
        //Cargar Doctores
        //public List<Doctor> CargarDoctores()
        //{
        //    List<Doctor> listaDoctores = new();

        //    if (File.Exists(Path_Doctor))
        //    {
        //        /*Leer archivo*/
        //        using (StreamReader strReader = new StreamReader(Path_Doctor))
        //        {
        //            string ln = string.Empty;

        //            while ((ln = strReader.ReadLine()) != null)
        //            {
        //                string[] campos = ln.Split(",");

        //                Doctor doctor = new()
        //                {
        //                    Cedula = campos[0],
        //                    Nombre = campos[1],
        //                    Apellido = campos[2],
        //                    NumeroDeTelefono = campos[3]
        //                };
        //                listaDoctores.Add(doctor);
        //            }
        //        }
        //    }
        //    return listaDoctores;
        //}

        ////Cargar Clientes
        //public List<Cliente> CargarClientes()
        //{
        //    List<Cliente> listaClientes = new();

        //    if (File.Exists(Path_Cliente))
        //    {
        //        /*Leer archivo*/
        //        using (StreamReader strReader = new StreamReader(Path_Cliente))
        //        {
        //            string ln = string.Empty;

        //            while ((ln = strReader.ReadLine()) != null)
        //            {
        //                string[] campos = ln.Split(",");

        //                Cliente cliente = new()
        //                {
        //                    Nombre = campos[0],
        //                    Apellido = campos[1],
        //                    FechaDeNacimiento = DateTime.Parse(campos[2]),
        //                    Direccion = campos[3]
        //                };
        //                listaClientes.Add(cliente);
        //            }
        //        }
        //    }
        //    return listaClientes;
        //}

        #endregion
    }
}
