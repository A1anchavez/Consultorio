using Consultorio.Business.Entidades;
using Consultorio.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.InMemroy
{
    public class ConsultaMemoryRepository : IRepository<Consulta>
    {
        /*** Persistencia en Memoria ***/
        private List<Consulta> Consulta = new List<Consulta>();

        public void Actualizar(Consulta t)
        {
            throw new NotImplementedException();
        }

        /********************************/
        public void Agregar(Consulta entity)
        {
            Consulta.Add(entity);
        }

        public List<Consulta> Consultar()
        {
            return Consulta;
        }

        public Consulta ConsultarPorId(string Id)
        {
            return Consulta.Where(x => x.Id.Equals(Id)).FirstOrDefault();
        }

        public void Eliminar(string Id, Consulta t)
        {
            throw new NotImplementedException();
        }

        public void Guardar(List<Consulta> entidades)
        {
            Consulta = entidades;
        }

        public void GuardarCambios()
        {
            throw new NotImplementedException();
        }
    }
}
