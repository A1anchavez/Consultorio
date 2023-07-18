using ConsultorioDapper.Dapper;
using Microsoft.AspNetCore.Mvc;

namespace ConsultorioDapper.Controllers
{
    [Route("api/doctores")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorRepository _Repo;

        public DoctorController(IDoctorRepository Repo)
        {
            _Repo = Repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetDoctores()
        {
            var doctores = await _Repo.GetDoctores();

            return Ok(doctores);
        }
    }
}
