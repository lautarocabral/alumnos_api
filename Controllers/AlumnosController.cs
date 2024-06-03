using alumnos_api.Models;
using alumnos_api.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace alumnos_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnosController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AlumnosController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Alumnos
        [HttpGet]
        public async Task<IActionResult> GetAlumnos()
        {
            var alumnos = await _unitOfWork.Alumnos.GetAll();
            if (alumnos == null)
            {
                return Ok(new ApiResponse(404, "No se encontraron alumnos"));
            }
            return Ok(new ApiResponse(200, "Lista de alumnos obtenida con éxito", alumnos));
        }

        // GET: api/Alumnos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAlumno(int id)
        {
            var alumnos = await _unitOfWork.Alumnos.Get(id);
            if (alumnos == null)
            {
                return Ok(new ApiResponse(404, $"No se encontró el Alumno con ID {id}"));
            }
            return Ok(new ApiResponse(200, "Alumno obtenida con éxito", alumnos));
        }

        // POST: api/Alumnos
        [HttpPost]
        public async Task<IActionResult> PostAlumno(Alumno alumno)
        {
            try
            {
                var newAlumno = await _unitOfWork.Alumnos.Add(alumno);
                await _unitOfWork.CompleteAsync();
                return CreatedAtAction("GetAlumno", new { id = newAlumno.AlumnoId }, new ApiResponse(201, "Alumno creado con éxito", newAlumno));
            }
            catch
            {
                return BadRequest(new ApiResponse(400, "No se pudo crear el alumno"));
            }
        }

        // PUT: api/Alumnos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlumno(int id, Alumno alumno)
        {
            if (id != alumno.AlumnoId)
            {
                return BadRequest(new ApiResponse(400, "El ID del alumno no coincide"));
            }

            try
            {
                await _unitOfWork.Alumnos.Update(id, alumno);
                await _unitOfWork.CompleteAsync();
                return Ok(new ApiResponse(204, "Alumno actualizado con éxito"));
            }
            catch
            {
                return NotFound(new ApiResponse(404, $"No se encontró el alumno con ID {id} para actualizar"));
            }
        }

        // DELETE: api/Alumnos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlumno(int id)
        {
            try
            {
                await _unitOfWork.Alumnos.Delete(id);
                await _unitOfWork.CompleteAsync();
                return Ok(new ApiResponse(200, "Alumno eliminado con éxito"));
            }
            catch
            {
                return NotFound(new ApiResponse(404, $"No se encontró el alumno con ID {id} para eliminar"));
            }
        }
    }
}
