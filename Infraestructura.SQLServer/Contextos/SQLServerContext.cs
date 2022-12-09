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
        public DbSet<Consulta> Consultas { get; set; }

        public SQLServerContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("dbo");


            builder.Entity<Cliente>().ToTable("Clientes","cat").HasKey(e=>e.Id);
            builder.Entity<Cliente>().Property(p => p.Nombre).HasMaxLength(50).IsRequired().HasColumnName("nombreCliente");
            builder.Entity<Cliente>().Property(p => p.Apellido).HasMaxLength(50).IsRequired().HasColumnName("apellidoCliente");
            builder.Entity<Cliente>().Property(p => p.FechaDeNacimiento).IsRequired().HasColumnName("fechaDeNacimientoCliente");
            builder.Entity<Cliente>().Property(p => p.Direccion).HasMaxLength(200).IsRequired().HasColumnName("direccionCliente");


            builder.Entity<Doctor>().ToTable("Doctores","cat").HasKey(e=>e.Id);
            builder.Entity<Doctor>().Property(p => p.Cedula).HasMaxLength(16).IsRequired().HasColumnName("cedulaDoctor");
            builder.Entity<Doctor>().Property(p => p.Nombre).HasMaxLength(50).IsRequired().HasColumnName("nombreDoctor");
            builder.Entity<Doctor>().Property(p => p.Apellido).HasMaxLength(50).IsRequired().HasColumnName("apellidoDoctor");
            builder.Entity<Doctor>().Property(p => p.NumeroDeTelefono).HasMaxLength(10).IsRequired().HasColumnName("numeroTelefonoDoctor");

            builder.Entity<Consulta>().ToTable("RegConsultas", "At").HasKey(sc => sc.Id);
            builder.Entity<Consulta>().HasOne<Cliente>(sc => sc.Cliente).WithMany(s => s.Consultas).HasForeignKey(e=>e.ClienteId);
            builder.Entity<Consulta>().HasOne<Doctor>(sc => sc.Doctor).WithMany(s => s.Consultas).HasForeignKey(e => e.DoctorId);


        }
    }
}
