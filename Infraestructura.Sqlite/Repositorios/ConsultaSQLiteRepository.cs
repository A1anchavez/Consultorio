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
    public class ConsultaSQLiteRepository: Repository<Consulta>
    {
        public ConsultaSQLiteRepository(DbContext context) : base(context)
        {
        }
    }
}
