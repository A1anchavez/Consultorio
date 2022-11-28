using Consultorio.Business.Entidades;
using Consultorio.Infraestructura.SQLite.Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Sqlite.Repositorios
{
    public class ClienteSqliteRepository : Repository<Cliente>
    {
        public ClienteSqliteRepository(DbContext context) : base(context)
        {
        }
    }
}
