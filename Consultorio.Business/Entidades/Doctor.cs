using Consultorio.Business.Interfaces;
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
    public class Doctor: Persona, IEntity
    {
        private readonly string Path = "C:\\Users\\alan.chavez\\Desktop\\Entrenamiento Desarollo\\Residencias Consultorio\\ListaDoctores.csv";
        public readonly IRepository<Doctor> repository;
        private string _cedula;
        private string _numeroDeTelefono;
        public string Cedula { 
            get => _cedula; 
            set => _cedula = value.IsNumber(nameof(Cedula)).LowerThan(17,nameof(Cedula)).HasWhiteSpace(nameof(Cedula)).HasDash(nameof(Cedula)); 
        }
        
        public string NumeroDeTelefono { 
            get => _numeroDeTelefono; 
            set => _numeroDeTelefono = value.IsNumber(nameof(NumeroDeTelefono)).EqualsNumber(10,nameof(NumeroDeTelefono)).HasWhiteSpace(nameof(NumeroDeTelefono)); 
        }


        //Propiedad de navegacion
        public List<Consulta> Consultas { get; set; }

        public Doctor(IRepository<Doctor> repo)
        {
            repository = repo;
        }
        public Doctor()
        {
            Id ??= Guid.NewGuid().ToString();
        }
                                                                                //numerodetelefono cambio de string a int
        public Doctor(IRepository<Doctor> repository, string cedula, string nombre, string apellidos, string numeroDeTelefono)
        {
            Cedula = cedula;
            Nombre = nombre;
            this.repository = repository;
            Apellido = apellidos;
            NumeroDeTelefono = numeroDeTelefono;
        }

        public override string ToString()
        {
            return $"{Id}, {Cedula}, {Nombre}, {Apellido},{NumeroDeTelefono}";
        }
        public void AgregarDoctor()
        {

            Doctor doctor = new Doctor()
            {
                Cedula = Cedula,
                Nombre = Nombre,
                Apellido = Apellido,
                NumeroDeTelefono = NumeroDeTelefono
            };

            AgregarDoctor(doctor);
        }
        public void AgregarDoctor(Doctor doctor)
        {

            if (string.IsNullOrEmpty(Cedula) || string.IsNullOrEmpty(Nombre) || string.IsNullOrEmpty(Apellido) || string.IsNullOrEmpty(NumeroDeTelefono))
            {
                throw new ArgumentException("Las propiedades deben tener un valor. " +
                    "La propiedadad Cedula, Nombre o Numero de telefono estan vacias");
            }
            //ToDo: Validar si numero de telefono es numerico
            //Validar si numero de telefono es numerico


            /** Persistir Elemento en un archivo **/
            using (StreamWriter strWriter = new StreamWriter(Path, true))
            {
                strWriter.WriteLine(doctor.ToString());
                strWriter.Close();
            }
        }
        public List<Doctor> CargarDoctores()
        {
            List<Doctor> listaDoctores = new();

            if (File.Exists(Path))
            {
                /*Leer archivo*/
                using (StreamReader strReader = new StreamReader(Path))
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
                            NumeroDeTelefono = campos[3]//int.Parse(campos[3])
                        };
                        listaDoctores.Add(doctor);
                    }
                }
            }
            return listaDoctores;
        }
        public void GuardarListaDoctores(List<Doctor> ListaDoctores)
        {
            foreach (Doctor doctor in ListaDoctores)
            {
                using (StreamWriter strWriter = new StreamWriter(Path, true))
                {
                    strWriter.WriteLine(doctor.ToString());
                    strWriter.Close();
                }

            }
        }
    }
}
