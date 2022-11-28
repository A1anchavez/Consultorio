using Consultorio.Business.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Sqlite.Contextos
{
    public class SQLiteContext : DbContext
    {
        public DbSet<Cliente> cliente { get; set; }
        public DbSet<Doctor> doctor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlite("Server = LAP-ALANC\\SQLEXPRESS; DataBase = Consultorio; Trusted_Connection = true");
        }
    }
}
