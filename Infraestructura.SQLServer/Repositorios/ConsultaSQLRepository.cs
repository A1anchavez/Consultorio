using Api_Consultorio.Modelos;
using Consultorio.Business.Entidades;
using Consultorio.Business.Interfaces.Repositorios;
using Consultorio.Business.Modelos;
using Consultorio.Business.Soportes;
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

        public PagedList<Consulta> Consultar(ConsultaParameters consultaParameters)
        {
            return PagedList<Consulta>.ToPagedList(FindAll().Include(x=> x.Cliente).Include(x=> x.Doctor).OrderBy(on => on.FechaConsulta),
                        consultaParameters.PageNumber, consultaParameters.PageSize);
        }
    }
}
