using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api_Consultorio.Modelos;
using Consultorio.Business.Entidades;
using Consultorio.Business.Interfaces.Repositorios;
using Consultorio.Business.Modelos;
using Consultorio.Business.Soportes;
using Infraestructura.SQLServer.Contextos;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.SQLServer.Repositorios
{
    public class ClienteSQLRepository: Repository<Cliente>,IClienteRepository
    {
        public ClienteSQLRepository(SQLServerContext context): base(context)
        {

        }

        public PagedList<Cliente> Consultar(ClienteParameters clienteParameters)
        {
            return PagedList<Cliente>.ToPagedList(FindAll().OrderBy(on => on.Nombre),
            clienteParameters.PageNumber, clienteParameters.PageSize);
        }

        public Cliente ConsultarPorExistencia(string nombre, string apellido, DateTime? fecha)
        {

            var result = 
                Consultar().FirstOrDefault((x) => 
                {
                    return x.Nombre == nombre && x.Apellido == apellido && x.FechaDeNacimiento.Value.Date == fecha.Value.Date;
                }
                );
            return result;
        }

        public Cliente ConsultarporNombre(string nombre) => Consultar().FirstOrDefault(x => x.Nombre == nombre)!;
        

        public bool FechaDisponible(string clienteId, DateTime? fecha)
        {
            var cliente = _context.Set<Cliente>().Where(x => x.Consultas.Where(x => x.ClienteId == clienteId && x.FechaConsulta.Date == fecha.Value.Date).Any())
                .Include(x => x.Consultas).ToList();
            return !cliente.Any();
        }
    }
}
