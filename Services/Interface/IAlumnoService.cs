using alumnos_api.Models;

namespace alumnos_api.Services.Interface
{
    public interface IAlumnoService
    {
        Task<List<Alumno>> GetAll();
        Task<Alumno> Get(int id);
        Task<Alumno> Add(Alumno alumno);
        Task<Alumno> Update(int id, Alumno alumno);
        Task Delete(int id);
    }
}
