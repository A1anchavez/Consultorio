using Consultorio.Business.Entidades;
using Consultorio.Business.Interfaces;
using Infraestructura.SQLServer.Contextos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.SQLServer.Repositorios
{
    public class ConsultaSQLRepository : Repository<Consulta>, IConsultaRepository
    {
        public ConsultaSQLRepository(SQLServerContext context) : base(context)
        {

        }

        public IEnumerable<Consulta> ConsultarCitasPrevias(string DoctorId)
        {
            throw new NotImplementedException();
        }
    }
}
