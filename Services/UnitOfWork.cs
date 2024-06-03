using alumnos_api.Models;
using alumnos_api.Services.Interface;

namespace alumnos_api.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GestionDbContext _context;
        public IAlumnoService Alumnos { get; private set; }
        public IMateriaService Materias { get; private set; }

        public UnitOfWork(GestionDbContext context)
        {
            _context = context;
            Alumnos = new AlumnoService(_context);
            Materias = new MateriaService(_context);
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
