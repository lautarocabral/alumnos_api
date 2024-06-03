using alumnos_api.Models;
using alumnos_api.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace alumnos_api.Services
{
    public class MateriaService : IMateriaService
    {
        private readonly GestionDbContext _context;

        public MateriaService(GestionDbContext context)
        {
            _context = context;
        }

        public async Task<List<Materia>> GetAll()
        {
            return await _context.Materias.ToListAsync();
        }

        public async Task<Materia> Get(int id)
        {
            return await _context.Materias.FindAsync(id);
        }

        public async Task<Materia> Add(Materia materia)
        {
            _context.Materias.Add(materia);
            await _context.SaveChangesAsync();
            return materia;
        }

        public async Task<Materia> Update(int id, Materia materia)
        {
            var materiaToUpdate = await _context.Materias.FindAsync(id);
            if (materiaToUpdate != null)
            {
                // Update properties
                _context.Entry(materiaToUpdate).CurrentValues.SetValues(materia);
                await _context.SaveChangesAsync();
            }
            return materiaToUpdate;
        }

        public async Task Delete(int id)
        {
            var materia = await _context.Materias.FindAsync(id);
            if (materia != null)
            {
                _context.Materias.Remove(materia);
                await _context.SaveChangesAsync();
            }
        }
    }
}
