using Api_Consultorio.Modelos;
using Consultorio.Business.Entidades;
using Consultorio.Business.Interfaces.Common;
using Consultorio.Business.Soportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Business.Interfaces.Repositorios
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Cliente ConsultarPorExistencia(string nombre, string apellido, DateTime? fecha);
        Cliente ConsultarporNombre(string nombre);
        IEnumerable<Cliente> Consultar(ClienteParameters clienteParameters);
        bool FechaDisponible(string clienteId, DateTime fecha);

    }
}
