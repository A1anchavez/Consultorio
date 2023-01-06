using Consultorio.Business.Entidades;
using Consultorio.Business.Interfaces.Repositorios;
using Consultorio.Business.Modelos;
using Consultorio.Business.Soportes;
using Infraestructura.SQLServer.Contextos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.SQLServer.Repositorios
{
    public class DoctorSQLRepository: Repository<Doctor>, IDoctorRepository
    {
        public DoctorSQLRepository(SQLServerContext context):base(context)
        {

        }

        public PagedList<Doctor> Consultar(DoctorParameters doctorParameters)
        {
            return PagedList<Doctor>.ToPagedList(FindAll().OrderBy(on=> on.Nombre),
                doctorParameters.PageNumber, doctorParameters.PageSize);
        }

        public bool FechaDisponible(string doctorId, DateTime? fecha)
        {

            //var doctor = _context.Set<Doctor>().Where(x => x.Id == doctorId)
            //    .Include(x => x.Consultas.Where(x => x.FechaConsulta.Date == fecha && x.DoctorId == doctorId)).ToList();
            //var doctor1 = _context.Set<Doctor>().Where(x => x.Id == doctorId && x.Consultas.Where(x => x.FechaConsulta.Date == fecha).Any())
            //    .Include(x=> x.Consultas).ToList();
            var doctor = _context.Set<Doctor>().Where(x => x.Consultas.Where(x => x.DoctorId == doctorId && x.FechaConsulta.Date == fecha.Value.Date).Any())
                .Include(x => x.Consultas).ToList();
            //var doctor3 = _context.Set<Doctor>()
            //    .Include(x => x.Consultas).Where(x => x.Consultas.Where(x => x.DoctorId == doctorId && x.FechaConsulta.Date == fecha).Any()).ToList();
            return !doctor.Any();

        }
    }
}
