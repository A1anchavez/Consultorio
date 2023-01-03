using System;
using Consultorio.Business.Entidades;


namespace Consultorio.Business.Interfaces.Servicios
{
    public interface IDoctorServices
    {
        public Doctor ConsultarDoctorPorId(string id);
    }
}