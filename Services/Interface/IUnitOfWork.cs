namespace alumnos_api.Services.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IAlumnoService Alumnos { get; }
        IMateriaService Materias { get; }
        Task<int> CompleteAsync();
    }
}
