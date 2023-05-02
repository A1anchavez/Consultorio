using Api_Consultorio.Contexto;
using Consultorio.Business.Entidades;
using Consultorio.Business.Interfaces.Servicios;
using Consultorio.Business.Modelos;
using Consultorio.Business.Soportes;

namespace Api_Consultorio.Dapper.Servicios
{
    public class DoctorDapperService : IDoctorServices
    {
        private readonly DapperContext _context;

        public DoctorDapperService(DapperContext context)
        {
            _context = context;
        }

        public async Task<Doctor> ActualizarDoctor(string id, string cedula, string nombre, string apellido, string numCel)
        {
            throw new NotImplementedException();
        }

        public async Task <Doctor> AgregarDoctor(string cedula, string nombre, string apellido, string numCel)
        {
            throw new NotImplementedException();
        }

        public async PagedList<Doctor> ConsultarDoctores(DoctorParameters doctorParameters)
        {
            throw new NotImplementedException();
        }

        public async Task<Doctor> ConsultarDoctorPorId(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Doctor> EliminarDoctor(string id)
        {
            throw new NotImplementedException();
        }
    }
}
