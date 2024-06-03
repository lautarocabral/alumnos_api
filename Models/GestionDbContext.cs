using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration; 

namespace alumnos_api.Models
{
    public class GestionDbContext : DbContext 
    {
        protected readonly IConfiguration Configuration;
        public GestionDbContext(IConfiguration configuration) : base() 
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // Conectarse a SQL Server con la cadena de conexión de app settings
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Alumno> Alumnos { get; set; } 
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Nota> Notas { get; set; }
    }
}
