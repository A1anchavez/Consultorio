﻿using Consultorio.Business.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Business.Interfaces
{
    public interface IConsultaRepository:IRepository<Consulta>
    {
        IEnumerable<Consulta> ConsultarCitasPrevias(string DoctorId);
    }
}
