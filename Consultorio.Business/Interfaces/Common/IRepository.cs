using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Business.Interfaces.Common
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        void GuardarCambios();
        void Guardar(List<T> entidades);
        void Agregar(T entity);
        List<T> Consultar();
        IQueryable<T> FindAll();
        T ConsultarPorId(string Id);
        void Actualizar(T t);
        void Eliminar(T t);
    }
}
