using Api_Consultorio.Modelos;
using Consultorio.Business.Entidades;
using Consultorio.Business.Interfaces.Common;
using Consultorio.Business.Modelos;
using Consultorio.Business.Soportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Business.Interfaces.Repositorios
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        PagedList<Doctor> Consultar(DoctorParameters doctorParameters);
        bool FechaDisponible(string clienteId, DateTime? fecha);
    }
}
