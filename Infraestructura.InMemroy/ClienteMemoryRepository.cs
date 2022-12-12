
using Consultorio.Business.Entidades;
using Consultorio.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Infraestructura.InMemory
{
    public class ClienteMemoryRepository : IRepository<Cliente>
    {
        /*** Persistencia en Memoria ***/
        private List<Cliente> Cliente = new List<Cliente>();
        /********************************/
        public void Agregar(Cliente entity)
        {
            Cliente.Add(entity);
        }
        public List<Cliente> Consultar()
        {
            return Cliente;
        }
        public Cliente ConsultarPorId(string id)
        {
            return Cliente.Where(x => x.Id.Equals(id)).FirstOrDefault();
        }
        public void Guardar(List<Cliente> entidades)
        {
            Cliente = entidades;
        }

        public void GuardarCambios()
        {
        }
    }
}