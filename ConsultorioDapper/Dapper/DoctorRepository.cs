using ConsultorioDapper.Entidad;
using Dapper;

namespace ConsultorioDapper.Dapper
{
    public class DoctorRepository: IDoctorRepository
    {
        private readonly DapperContext _context;
        public DoctorRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Doctor>> GetDoctores()
        {
            var query = "SELECT * FROM Doctores";
            using (var connection = _context.CreateConnection())
            {
                var doctores = await connection.QueryAsync<Doctor>(query);

                return doctores.ToList();
            }
        }
    }
}
