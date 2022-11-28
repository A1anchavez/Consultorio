//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Consultorio.Business.Entidades
//{
//    public class Cliente
//    {
//        private readonly string Path = "C:\\Users\\alan.chavez\\Desktop\\Entrenamiento Desarollo\\Residencias Consultorio\\ListaClientes.csv";

//        public string Nombre { get; set; }
//        public string Apellidos { get; set; }
//        public DateTime FechaDeNacimiento { get; set; }
//        public string Direccion { get; set; }

//        public Cliente()
//        {

//        }
//        public Cliente(string nombre, string apellidos, DateTime fechaDeNacimiento, string direccion)
//        {
//            Nombre = nombre;
//            Apellidos = apellidos;
//            FechaDeNacimiento = fechaDeNacimiento;
//            Direccion = direccion;

//        }


//        public override string ToString()
//        {
//            return $"{Nombre}, {Apellidos}, {FechaDeNacimiento}, {Direccion}";
//        }







//        public void AgregarCliente()
//        {

//            Cliente cliente = new Cliente()
//            {
//                Nombre = Nombre,
//                Apellidos = Apellidos,
//                FechaDeNacimiento = FechaDeNacimiento,
//                Direccion = Direccion
//            };

//            AgregarCliente(cliente);

//        }

//        public void AgregarCliente(Cliente cliente)
//        {

//            if (string.IsNullOrEmpty(Nombre) || string.IsNullOrEmpty(Apellidos) || string.IsNullOrEmpty(Direccion))
//            {
//                throw new ArgumentException("Las propiedades deben tener un valor. " +
//                    "La propiedadad Nombre, Apellidos o Direccion estan vacias");
//            }


//            /** Persistir Elemento en un archivo **/
//            using (StreamWriter strWriter = new StreamWriter(Path, true))
//            {

//                strWriter.WriteLine(cliente.ToString());
//                strWriter.Close();
//            }
//        }


//        public List<Cliente> CargarCliente()
//        {
//            List<Cliente> listaClientes = new();

//            if (File.Exists(Path))
//            {
//                /*Leer archivo*/
//                using (StreamReader strReader = new StreamReader(Path))
//                {
//                    string ln = string.Empty;

//                    while ((ln = strReader.ReadLine()) != null)
//                    {
//                        string[] campos = ln.Split(",");

//                        Cliente cliente = new()
//                        {
//                            Nombre = campos[0],
//                            Apellidos = campos[1],
//                            FechaDeNacimiento = DateTime.Parse(campos[2]),
//                            Direccion = campos[3]
//                        };
//                        listaClientes.Add(cliente);
//                    }
//                }
//            }
//            return listaClientes;
//        }

//        public void GuardarListaClientes(List<Cliente> ListaClientes)
//        {
//            foreach (Cliente cliente in ListaClientes)
//            {
//                using (StreamWriter strWriter = new StreamWriter(Path, true))
//                {
//                    strWriter.WriteLine(cliente.ToString());
//                    strWriter.Close();
//                }

//            }
//        }
//    }
//}
