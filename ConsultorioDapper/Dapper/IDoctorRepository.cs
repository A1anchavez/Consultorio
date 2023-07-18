using ConsultorioDapper.Entidad;

namespace ConsultorioDapper.Dapper
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<Doctor>> GetDoctores();
    }
}
