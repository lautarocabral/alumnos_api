using alumnos_api.Models;
using alumnos_api.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace alumnos_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriasController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public MateriasController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Materias
        [HttpGet]
        public async Task<IActionResult> GetMaterias()
        {
            var materias = await _unitOfWork.Materias.GetAll();
            if (materias == null)
            {
                return Ok(new ApiResponse(404, "No se encontraron materias"));
            }
            return Ok(new ApiResponse(200, "Lista de materias obtenida con éxito", materias));
        }

        // GET: api/Materias/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMateria(int id)
        {
            var materia = await _unitOfWork.Materias.Get(id);
            if (materia == null)
            {
                return Ok(new ApiResponse(404, $"No se encontró la materia con ID {id}"));
            }
            return Ok(new ApiResponse(200, "Materia obtenida con éxito", materia));
        }

        // POST: api/Materias
        [HttpPost]
        public async Task<IActionResult> PostMateria(Materia materia)
        {
            try
            {
                var newMateria = await _unitOfWork.Materias.Add(materia);
                await _unitOfWork.CompleteAsync();
                return CreatedAtAction("GetMateria", new { id = newMateria.MateriaId }, new ApiResponse(201, "Materia creada con éxito", newMateria));
            }
            catch
            {
                return BadRequest(new ApiResponse(400, "No se pudo crear la materia"));
            }
        }

        // PUT: api/Materias/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMateria(int id, Materia materia)
        {
            if (id != materia.MateriaId)
            {
                return BadRequest(new ApiResponse(400, "El ID de la materia no coincide"));
            }

            try
            {
                await _unitOfWork.Materias.Update(id, materia);
                await _unitOfWork.CompleteAsync();
                return NoContent(); // O considera retornar Ok(new ApiResponse(204, "Materia actualizada con éxito"));
            }
            catch
            {
                return NotFound(new ApiResponse(404, $"No se encontró la materia con ID {id} para actualizar"));
            }
        }

        // DELETE: api/Materias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMateria(int id)
        {
            try
            {
                await _unitOfWork.Materias.Delete(id);
                await _unitOfWork.CompleteAsync();
                return Ok(new ApiResponse(200, "Materia eliminada con éxito"));
            }
            catch
            {
                return NotFound(new ApiResponse(404, $"No se encontró la materia con ID {id} para eliminar"));
            }
        }
    }
}
