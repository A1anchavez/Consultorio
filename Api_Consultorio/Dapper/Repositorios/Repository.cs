using Api_Consultorio.Contexto;
using Consultorio.Business.Entidades;
using Consultorio.Business.Interfaces.Common;

namespace Api_Consultorio.Dapper.Repositorios
{
    public class Repository<T> : IRepository<T> where T : class, IEntity, new()
    {
        private readonly DapperContext _context;

        public void Actualizar(T t)
        {
            throw new NotImplementedException();
        }

        public void Agregar(T entity)
        {
            throw new NotImplementedException();
        }

        public List<T> Consultar()
        {
            throw new NotImplementedException();
        }

        public T ConsultarPorId(string Id)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(T t)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> FindAll()
        {
            throw new NotImplementedException();
        }

        public void Guardar(List<T> entidades)
        {
            throw new NotImplementedException();
        }

        public void GuardarCambios()
        {
            throw new NotImplementedException();
        }
    }
}
