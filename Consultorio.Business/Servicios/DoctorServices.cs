using Consultorio.Business.Entidades;
using Consultorio.Business.Interfaces.Repositorios;
using Consultorio.Business.Interfaces.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Business.Servicios
{
    public class DoctorServices : IDoctorServices
    {
        private readonly IClienteRepository _clienteRepo;
        private readonly IConsultaRepository _consultaRepo;
        private readonly IDoctorRepository _repo;

        public DoctorServices(IDoctorRepository repo, IConsultaRepository consultaRepo,
        IClienteRepository clienteRepo)
        {
            this._repo = repo;
            _consultaRepo = consultaRepo;
            _clienteRepo = clienteRepo;
        }
        public Doctor ConsultarDoctorPorId(string id)
        {
            var doctor = _repo.Consultar().Where(x => x.Id == id).FirstOrDefault();
            return doctor;

        }
    }
}
