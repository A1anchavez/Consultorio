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

            //Tabla y condiciones de cliente
            builder.Entity<Cliente>().ToTable("Clientes","cat").HasKey(e=>e.Id);
            builder.Entity<Cliente>().Property(p => p.Nombre).HasMaxLength(50).IsRequired().HasColumnName("nombreCliente");
            builder.Entity<Cliente>().Property(p => p.Apellido).HasMaxLength(50).IsRequired().HasColumnName("apellidoCliente");
            builder.Entity<Cliente>().Property(p => p.FechaDeNacimiento).IsRequired().HasColumnName("fechaDeNacimientoCliente");
            builder.Entity<Cliente>().Property(p => p.Direccion).HasMaxLength(200).IsRequired().HasColumnName("direccionCliente");

            //Tabla y condiciones de doctor
            builder.Entity<Doctor>().ToTable("Doctores","cat").HasKey(e=>e.Id);
            builder.Entity<Doctor>().Property(p => p.Cedula).HasMaxLength(16).IsRequired().HasColumnName("cedulaDoctor");
            builder.Entity<Doctor>().Property(p => p.Nombre).HasMaxLength(50).IsRequired().HasColumnName("nombreDoctor");
            builder.Entity<Doctor>().Property(p => p.Apellido).HasMaxLength(50).IsRequired().HasColumnName("apellidoDoctor");
            builder.Entity<Doctor>().Property(p => p.NumeroDeTelefono).HasMaxLength(10).IsRequired().HasColumnName("numeroTelefonoDoctor");

            //Tabla y condiciones de consulta
            builder.Entity<Consulta>().ToTable("RegConsultas", "At").HasKey(sc => sc.Id);
            builder.Entity<Consulta>().HasOne<Cliente>(sc => sc.Cliente).WithMany(s => s.Consultas).HasForeignKey(e=>e.ClienteId);
            builder.Entity<Consulta>().HasOne<Doctor>(sc => sc.Doctor).WithMany(s => s.Consultas).HasForeignKey(e => e.DoctorId);
            builder.Entity<Consulta>().Property(p=>p.FechaConsulta).IsRequired().HasColumnName("fechaDeConsulta");
            builder.Entity<Consulta>().Property(p => p.Motivo).HasMaxLength(150).HasColumnName("motivo");

            //Usuario
            builder.Entity<Usuario>().ToTable("Usuarios", "cat").HasKey(e => e.Id);
            builder.Entity<Usuario>().Property(p => p.NombreUsuario).HasMaxLength(50).IsRequired().HasColumnName("nombreUsuario");
            builder.Entity<Usuario>().Property(p => p.Contraseña).HasMaxLength(50).IsRequired().HasColumnName("contraseña");
            builder.Entity<Usuario>().Property(p => p.Rol).HasMaxLength(50).IsRequired().HasColumnName("rol");
        }
    }
}
