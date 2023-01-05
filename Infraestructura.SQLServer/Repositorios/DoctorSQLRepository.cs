using Consultorio.Business.Entidades;
using Consultorio.Business.Interfaces.Repositorios;
using Consultorio.Business.Modelos;
using Consultorio.Business.Soportes;
using Infraestructura.SQLServer.Contextos;
using System;
using System.Collections.Generic;
using System.Linq;
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
            return !ConsultarPorId(doctorId).
                Consultas.Any(x => x.FechaConsulta.Date == fecha);
        }
    }
}
