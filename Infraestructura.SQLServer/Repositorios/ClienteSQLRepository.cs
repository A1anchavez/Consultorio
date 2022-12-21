using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api_Consultorio.Modelos;
using Consultorio.Business.Entidades;
using Consultorio.Business.Interfaces;
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

        public IEnumerable<Cliente> Consultar(ClienteParameters clienteParameters)
        {
            return Consultar()
                    .OrderBy(on => on.Nombre)
                    .Skip((clienteParameters.PageNumber - 1) * clienteParameters.PageSize)
                    .Take(clienteParameters.PageSize)
                    .ToList();
        }



        //public IEnumerable<Cliente> Consultar(ClienteParameters clienteParameters)
        //{
        //    //IQueryable<Cliente> no sabemos si esta bien

        //    //return PagedList<Cliente>.ToPagedList((FindAll().OrderBy(x => x.Nombre),
        //    //    clienteParameters.pageNumber, clienteParameters.PageSize));
        //    throw new NotImplementedException();


        //}
    }
}
