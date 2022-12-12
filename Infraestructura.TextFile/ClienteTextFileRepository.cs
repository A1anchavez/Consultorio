using Consultorio.Business.Entidades;
using Consultorio.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Infraestructura.TextFile
{
    public class ClienteTextFileRepository : IRepository<Cliente>
    {
        private const string path = "C:\\Users\\alan.chavez\\Desktop\\Entrenamiento Desarollo\\Residencias Consultorio\\ListaClientes.csv";

        public void Agregar(Cliente entity)
        {
            using (StreamWriter strWriter = new StreamWriter(path, true))
            {

                strWriter.WriteLine(entity.ToString());
                strWriter.Close();
            }
        }

        public List<Cliente> Consultar()
        {
            if (!System.IO.File.Exists(path))
            {
                return new List<Cliente>();
            }

            using (StreamReader strReader = new StreamReader(path))
            {

                List<Cliente> cliente = new List<Cliente>();
                string ln = string.Empty;

                while ((ln = strReader.ReadLine()) != null)
                {
                    string[] campos = ln.Split(",");

                    Cliente clientes = new Cliente()
                    {
                        //Id = campos[0],
                        Nombre = campos[1],
                        Apellido = campos[2],
                        FechaDeNacimiento = DateTime.Parse(campos[3]),
                        Direccion = campos[4]
                    };
                    cliente.Add(clientes);
                }

                return cliente;
            }
        }

        public Cliente ConsultarPorId(string id)
        {
            return Consultar().Where(x => x.Id.Equals(id)).FirstOrDefault();
        }

        public void Guardar(List<Cliente> entidades)
        {
            foreach (Cliente cliente in entidades)
            {
                using (StreamWriter strWriter = new StreamWriter(path, true))
                {
                    strWriter.WriteLine(cliente.ToString());
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