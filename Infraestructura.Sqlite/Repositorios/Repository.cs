using Consultorio.Business.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Consultorio.Infraestructura.SQLite.Repositorios
{
    public class Repository<T> : IRepository<T> where T : class, IEntity, new()
    {
        private readonly DbContext _context;
        public Repository(DbContext context)
        {
            _context = context;
        }

        public void Actualizar(T t)
        {
            throw new NotImplementedException();
        }

        public void Agregar(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }
        public List<T> Consultar()
        {
            return _context.Set<T>().ToList();
        }
        public T ConsultarPorId(string id)
        {
            return _context.Set<T>().Where(x => x.Id == id).ToList().FirstOrDefault();
        }

        public void Eliminar(string Id, T t)
        {
            throw new NotImplementedException();
        }

        public void Guardar(List<T> entidades)
        {
            _context.AddRange(entidades);
            _context.SaveChanges();
        }

        public void GuardarCambios()
        {
            _context.SaveChanges();
        }
    }
}