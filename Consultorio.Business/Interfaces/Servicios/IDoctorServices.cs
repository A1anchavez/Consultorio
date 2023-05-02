using System;
using System.Collections.Generic;
using Api_Consultorio.Modelos;
using Consultorio.Business.Entidades;
using Consultorio.Business.Modelos;
using Consultorio.Business.Soportes;

namespace Consultorio.Business.Interfaces.Servicios
{
    public interface IDoctorServices
    {
        Doctor AgregarDoctor(string cedula, string nombre, string apellido, string numCel);
        IEnumerable<Doctor> ConsultarDoctores();
        public Doctor ConsultarDoctorPorId(string id);
        Doctor ActualizarDoctor(string id, string cedula, string nombre, string apellido, string numCel);
        Doctor EliminarDoctor(string id);
    }
}