using Api_Consultorio.Modelos;
using Consultorio.Business.Entidades;
using Consultorio.Business.Soportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Business.Interfaces
{
    public interface IClienteRepository : IRepository<Cliente>
    {

        IEnumerable<Cliente> Consultar(ClienteParameters clienteParameters);
    }
}
