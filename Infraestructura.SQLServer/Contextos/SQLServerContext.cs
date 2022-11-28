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
        public DbSet<Cliente> cliente { get; set; }
        public DbSet<Doctor> doctor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server = LAP-ALANC\\SQLEXPRESS; DataBase = Consultorio; Trusted_Connection = true");
        }
    }
}
