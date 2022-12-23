﻿using Consultorio.Business.Entidades;
using Consultorio.Business.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Business.Interfaces.Repositorios
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        bool FechaDisponible(string clienteId, DateTime fecha);

    }
}
