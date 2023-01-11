using Api_Consultorio.Modelos;
using Consultorio.Business.Entidades;
using Consultorio.Business.Interfaces.Common;
using Consultorio.Business.Modelos;
using Consultorio.Business.Soportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Business.Interfaces.Repositorios
{
    public interface IConsultaRepository : IRepository<Consulta>
    {
        PagedList<Consulta> Consultar(ConsultaParameters consultaParameters);
    }
}
