using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Consultorio.Business.Entidades;

namespace Infraestructura.SQLServer.Contextos
{
    public class SQLServerContext : DbContext
    {
        public DbSet<Cliente>Clientes { get; set; }
        public DbSet<Doctor> Doctores { get; set; }

        public SQLServerContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {
            
        }

    }
}
