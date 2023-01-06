using Consultorio.Business.Entidades;
using Consultorio.Business.Interfaces.Repositorios;
using Infraestructura.SQLServer.Contextos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.SQLServer.Repositorios
{
    public class UsuarioSQLRepository: Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioSQLRepository(SQLServerContext context) : base(context)
        {

        }
    }
}
