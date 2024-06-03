using alumnos_api.Models;
using alumnos_api.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace alumnos_api.Services
{
    public class AlumnoService : IAlumnoService
    {
        private readonly GestionDbContext _context;
        public AlumnoService(GestionDbContext context)
        {
            _context = context;
        }

        public async Task<Alumno> Add(Alumno alumno)
        {
            _context.Alumnos.Add(alumno);
            await _context.SaveChangesAsync();
            return alumno;
        }

        public async Task Delete(int id)
        {
            var alumno = await _context.Alumnos.FindAsync(id);
            if (alumno != null)
            {
                _context.Alumnos.Remove(alumno);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Alumno> Get(int id)
        {
            return await _context.Alumnos.FindAsync(id);
        }

        public async Task<List<Alumno>> GetAll()
        {
            return await _context.Alumnos.ToListAsync();

        }

        public async Task<Alumno> Update(int id, Alumno alumno)
        {
            var alumnoToUpdate = await _context.Alumnos.FindAsync(id);
            if (alumnoToUpdate != null)
            {
                // Update properties
                _context.Entry(alumnoToUpdate).CurrentValues.SetValues(alumno);
                await _context.SaveChangesAsync();
            }
            return alumnoToUpdate;
        }
    }
}
