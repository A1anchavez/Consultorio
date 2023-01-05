using Consultorio.Business.Entidades;
using Consultorio.Business.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.TextFile
{
    public class ConsultaTextFileRepository: IRepository<Consulta>
    {
        private const string path = "C:\\Users\\alan.chavez\\Desktop\\Entrenamiento Desarollo\\Residencias Consultorio\\ListaConsultas.csv";

        public void Actualizar(Consulta t)
        {
            throw new NotImplementedException();
        }

        public void Agregar(Consulta entity)
        {
            using (StreamWriter strWriter = new StreamWriter(path, true))
            {

                strWriter.WriteLine(entity.ToString());
                strWriter.Close();
            }
        }

        public List<Consulta> Consultar()
        {
            if (!System.IO.File.Exists(path))
            {
                return new List<Consulta>();
            }

            using (StreamReader strReader = new StreamReader(path))
            {

                List<Consulta> consulta = new List<Consulta>();
                string ln = string.Empty;

                while ((ln = strReader.ReadLine()) != null)
                {
                    string[] campos = ln.Split(",");

                    Consulta consultas = new Consulta()
                    {
                        //Id = campos[0],

                        //ToDo: Revisar luego estas lineas comentadas
                        //formato string 
                        //Doctor = string.Format(campos[1]),
                        //Cliente = string.Format(campos[2]),
                        FechaConsulta = DateTime.Parse(campos[3]),
                        Motivo = campos[4]
                    };
                    consulta.Add(consultas);
                }

                return consulta;
            }
        }

        public Consulta ConsultarPorId(string Id)
        {
            return Consultar().Where(x => x.Id.Equals(Id)).FirstOrDefault();
        }

        public void Eliminar(Consulta t)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Consulta> FindAll()
        {
            throw new NotImplementedException();
        }

        public void Guardar(List<Consulta> entidades)
        {
            foreach (Consulta consulta in entidades)
            {
                using (StreamWriter strWriter = new StreamWriter(path, true))
                {
                    strWriter.WriteLine(consulta.ToString());
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
