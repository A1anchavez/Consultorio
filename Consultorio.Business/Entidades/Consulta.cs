using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Business.Entidades
{
    public class Consulta
    {
        private readonly string Path = "C:\\Users\\alan.chavez\\Desktop\\Entrenamiento Desarollo\\Residencias Consultorio\\ListaConsultas.csv";
        private readonly string Path_Doctor = "C:\\Users\\alan.chavez\\Desktop\\Entrenamiento Desarollo\\Residencias Consultorio\\ListaDoctores.csv";
        private readonly string Path_Cliente = "C:\\Users\\alan.chavez\\Desktop\\Entrenamiento Desarollo\\Residencias Consultorio\\ListaClientes.csv";
        
        ////////////
        public string Id { get; set; }
        public string ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public string DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        //////////
        public string nomDoctor { get; set; }
        public string nomCliente { get; set; }
        public DateTime fechaConsulta { get; set; }

        public string Motivo { get; set; }

        public Consulta()
        {

        }

        public Consulta(string nom_doctor, string nom_cliente, DateTime fecha_consulta, string motivo)
        {
            nomDoctor = nom_doctor;
            nomCliente = nom_cliente;
            fechaConsulta = fecha_consulta;
            Motivo = motivo;
        }
        public override string ToString()
        {
            return $"{nomDoctor}, {nomCliente}, {fechaConsulta},{Motivo}";
        }


        public void AgregarConsulta()
        {

            Consulta consulta = new Consulta()
            {
                nomDoctor = nomDoctor,
                nomCliente = nomCliente,
                fechaConsulta = fechaConsulta,
                Motivo = Motivo
            };

            AgregarConsulta(consulta);

        }

        public void AgregarConsulta(Consulta consulta)
        {

            if (string.IsNullOrEmpty(nomDoctor) || string.IsNullOrEmpty(nomCliente))
            {
                throw new ArgumentException("Las propiedades deben tener un valor. " +
                    "La propiedadad Nombre de el Doctor o Nombre de el Cliente estan vacias");
            }


            /** Persistir Elemento en un archivo **/
            using (StreamWriter strWriter = new StreamWriter(Path, true))
            {

                strWriter.WriteLine(consulta.ToString());
                strWriter.Close();
            }
        }


        public List<Consulta> CargarConsultas()
        {
            List<Consulta> listaConsultas = new();

            if (File.Exists(Path))
            {
                /*Leer archivo*/
                using (StreamReader strReader = new StreamReader(Path))
                {
                    string ln = string.Empty;

                    while ((ln = strReader.ReadLine()) != null)
                    {
                        string[] campos = ln.Split(",");

                        Consulta consulta = new()
                        {
                            nomDoctor = campos[0],
                            nomCliente = campos[1],
                            fechaConsulta = DateTime.Parse(campos[2]),
                            Motivo = campos[3]
                        };
                        listaConsultas.Add(consulta);
                    }
                }
            }
            return listaConsultas;
        }

        public void GuardarListaConsultas(List<Consulta> ListaConsultas)
        {
            foreach (Consulta consulta in ListaConsultas)
            {
                using (StreamWriter strWriter = new StreamWriter(Path, true))
                {
                    strWriter.WriteLine(consulta.ToString());
                    strWriter.Close();
                }

            }
        }

        #region cargar doctores y clientes
        //Cargar Doctores
        public List<Doctor> CargarDoctores()
        {
            List<Doctor> listaDoctores = new();

            if (File.Exists(Path_Doctor))
            {
                /*Leer archivo*/
                using (StreamReader strReader = new StreamReader(Path_Doctor))
                {
                    string ln = string.Empty;

                    while ((ln = strReader.ReadLine()) != null)
                    {
                        string[] campos = ln.Split(",");

                        Doctor doctor = new()
                        {
                            Cedula = campos[0],
                            Nombre = campos[1],
                            Apellido = campos[2],
                            NumeroDeTelefono = campos[3]
                        };
                        listaDoctores.Add(doctor);
                    }
                }
            }
            return listaDoctores;
        }

        //Cargar Clientes
        public List<Cliente> CargarClientes()
        {
            List<Cliente> listaClientes = new();

            if (File.Exists(Path_Cliente))
            {
                /*Leer archivo*/
                using (StreamReader strReader = new StreamReader(Path_Cliente))
                {
                    string ln = string.Empty;

                    while ((ln = strReader.ReadLine()) != null)
                    {
                        string[] campos = ln.Split(",");

                        Cliente cliente = new()
                        {
                            Nombre = campos[0],
                            Apellido = campos[1],
                            FechaDeNacimiento = DateTime.Parse(campos[2]),
                            Direccion = campos[3]
                        };
                        listaClientes.Add(cliente);
                    }
                }
            }
            return listaClientes;
        }

        #endregion
    }
}
