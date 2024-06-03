using alumnos_api.Models;

namespace alumnos_api.Services.Interface
{
    public interface IMateriaService
    {
        Task<List<Materia>> GetAll();
        Task<Materia> Get(int id);
        Task<Materia> Add(Materia materia);
        Task<Materia> Update(int id, Materia materia);
        Task Delete(int id);
    }
}
