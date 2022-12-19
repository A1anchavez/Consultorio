﻿using Consultorio.Business.Entidades;
using Consultorio.Business.Interfaces;
using Infraestructura.SQLServer.Contextos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.SQLServer.Repositorios
{
    public class DoctorSQLRepository: Repository<Doctor>, IDoctorRepository
    {
        public DoctorSQLRepository(SQLServerContext context):base(context)
        {

        }
    }
}