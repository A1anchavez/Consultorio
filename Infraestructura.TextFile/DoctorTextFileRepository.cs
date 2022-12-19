using Consultorio.Business.Entidades;
using Consultorio.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.TextFile
{
    public class DoctorTextFileRepository : IRepository<Doctor>
    {
        private const string path = "C:\\Users\\alan.chavez\\Desktop\\Entrenamiento Desarollo\\Residencias Consultorio\\ListaDoctores.csv";

        public void Agregar(Doctor entity)
        {
            using (StreamWriter strWriter = new StreamWriter(path, true))
            {

                strWriter.WriteLine(entity.ToString());
                strWriter.Close();
            }
        }

        public List<Doctor> Consultar()
        {
            if (!System.IO.File.Exists(path))
            {
                return new List<Doctor>();
            }

            using (StreamReader strReader = new StreamReader(path))
            {

                List<Doctor> doctor = new List<Doctor>();
                string ln = string.Empty;

                while ((ln = strReader.ReadLine()) != null)
                {
                    string[] campos = ln.Split(",");

                    Doctor doctores = new Doctor()
                    {
                        //Id = campos[0],
                        Cedula = campos[1],
                        Nombre = campos[2],
                        Apellido = campos[3],
                        NumeroDeTelefono = campos[4]
                    };
                    doctor.Add(doctores);
                }

                return doctor;
            }
        }

        public Doctor ConsultarPorId(string Id)
        {
            return Consultar().Where(x => x.Id.Equals(Id)).FirstOrDefault();
        }

        public void Guardar(List<Doctor> entidades)
        {
            foreach (Doctor doctor in entidades)
            {
                using (StreamWriter strWriter = new StreamWriter(path, true))
                {
                    strWriter.WriteLine(doctor.ToString());
                    strWriter.Close();
                }

            }
        }

        public void GuardarCambios()
        {
            throw new NotImplementedException();
        }
    }
}
