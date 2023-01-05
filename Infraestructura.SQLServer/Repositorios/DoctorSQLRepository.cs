using Consultorio.Business.Entidades;
using Consultorio.Business.Interfaces.Repositorios;
using Consultorio.Business.Modelos;
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

        public IEnumerable<Doctor> Consultar(DoctorParameters doctorParameters)
        {
            return Consultar()
                .OrderBy(ow=> ow.Nombre)
                .Skip((doctorParameters.PageNumber-1)*doctorParameters.PageSize)
                .Take(doctorParameters.PageSize)
                .ToList();
        }

        public bool FechaDisponible(string doctorId, DateTime? fecha)
        {
            return !ConsultarPorId(doctorId).
                Consultas.Any(x => x.FechaConsulta.Date == fecha);
        }
    }
}
