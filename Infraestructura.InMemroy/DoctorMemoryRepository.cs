using Consultorio.Business.Entidades;
using Consultorio.Business.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.InMemroy
{
    public class DoctorMemoryRepository : IRepository<Doctor>
    {
        /*** Persistencia en Memoria ***/
        private List<Doctor> Doctor = new List<Doctor>();

        public void Actualizar(Doctor t)
        {
            throw new NotImplementedException();
        }

        /********************************/
        public void Agregar(Doctor entity)
        {
            Doctor.Add(entity);
        }

        public List<Doctor> Consultar()
        {
            return Doctor;
        }

        public Doctor ConsultarPorId(string Id)
        {
            return Doctor.Where(x => x.Id.Equals(Id)).FirstOrDefault();
        }

        public void Eliminar(Doctor t)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Doctor> FindAll()
        {
            throw new NotImplementedException();
        }

        public void Guardar(List<Doctor> entidades)
        {
            Doctor = entidades;
        }

        public void GuardarCambios()
        {
            throw new NotImplementedException();
        }
    }
}
