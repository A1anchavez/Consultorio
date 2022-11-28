using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Consultorio.Business.Entidades;
using Infraestructura.SQLServer.Contextos;

namespace Infraestructura.SQLServer.Repositorios
{
    public class ClienteSQLRepository: Repository<Cliente>
    {
        public ClienteSQLRepository(SQLServerContext context): base(context)
        {

        }
    }
}
