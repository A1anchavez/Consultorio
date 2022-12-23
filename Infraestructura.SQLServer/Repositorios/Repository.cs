using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using Consultorio.Business.Interfaces.Common;

namespace Infraestructura.SQLServer.Repositorios
{
    public class Repository<T> : IRepository<T> where T: class, IEntity, new()
    {
        private readonly DbContext _context;
        public Repository(DbContext context)
        {
            _context = context;
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
        public T ConsultarPorId(string Id)
        {
            return _context.Set<T>().Where(x => x.Id== Id).ToList().FirstOrDefault();
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

        public void Actualizar(T t)
        {
            _context.Update(t);
            _context.SaveChanges();
        }
        public void Eliminar(string Id, T t)
        {
            _context.Remove(t);
            _context.SaveChanges();
        }

        public IQueryable<T> FindAll() => _context.Set<T>().AsNoTracking();

    }
}
