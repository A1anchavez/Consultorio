using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Clases
{
    public class Doctor
    {
        private readonly string Path = "C:\\Users\\alan.chavez\\Desktop\\Entrenamiento Desarollo\\Residencias Consultorio\\ListaDoctor.csv";
        
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string NumeroDeTelefono { get; set; }

        public Doctor()
        {

        }
        public Doctor(string cedula, string nombre, string apellidos, string numeroDeTelefono)
        {
            Cedula = cedula;
            Nombre = nombre;
            Apellidos = apellidos;
            NumeroDeTelefono = numeroDeTelefono;
        }

        public override string ToString()
        {
            return $"{Cedula}, {Nombre}, {Apellidos},{NumeroDeTelefono}";
        }
        public void AgregarDoctor()
        {

            Doctor doctor = new Doctor()
            {
                Cedula = Cedula,
                Nombre = Nombre,
                Apellidos = Apellidos,
                NumeroDeTelefono = NumeroDeTelefono
            };

            AgregarDoctor(doctor);
        }
        public void AgregarDoctor(Doctor doctor)
        {

            if (String.IsNullOrEmpty(Cedula) || String.IsNullOrEmpty(Nombre) || String.IsNullOrEmpty(Apellidos) || String.IsNullOrEmpty(NumeroDeTelefono))
            {
                throw new ArgumentException("Las propiedades deben tener un valor. " +
                    "La propiedadad Titulo o Descripcion estan vacias");
            }


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

            if (System.IO.File.Exists(Path))
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
                            Apellidos = campos[2],
                            NumeroDeTelefono = campos[3]
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
