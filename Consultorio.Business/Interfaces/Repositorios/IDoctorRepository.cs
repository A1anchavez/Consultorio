using Api_Consultorio.Modelos;
using Consultorio.Business.Entidades;
using Consultorio.Business.Interfaces.Common;
using Consultorio.Business.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Business.Interfaces.Repositorios
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        IEnumerable<Doctor> Consultar(DoctorParameters doctorParameters);
        bool FechaDisponible(string clienteId, DateTime? fecha);

    }
}
