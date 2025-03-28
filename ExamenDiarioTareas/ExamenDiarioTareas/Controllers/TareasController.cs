using ExamenDiarioTareas.Models;
using ExamenDiarioTareas.Services;
using Microsoft.AspNetCore.Mvc;
namespace ExamenDiarioTareas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareasController : ControllerBase
    {
        private readonly TareasService _tareasService;

        public TareasController(TareasService tareasService)
        {
            _tareasService = tareasService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Tarea>>> ObtenerTareas()
        {
            var tareas = await _tareasService.ObtenerTareas();
            return Ok(tareas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tarea>> ObtenerTareaPorId(Guid id)
        {
            var tarea = await _tareasService.ObtenerTareaPorId(id);
            if (tarea == null) return NotFound("Tarea no encontrada");

            return Ok(tarea);
        }

        [HttpPost]
        public async Task<ActionResult> CrearTarea([FromBody] Tarea tarea)
        {
            if (tarea == null)
            {
                return BadRequest("Datos de tarea vienen vacíos");
            }
            var nuevaTarea = await _tareasService.CrearTarea(tarea);
            return Ok(nuevaTarea);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> ActualizarTarea(Guid id, [FromBody] Tarea tareaActualizada)
        {
            if (tareaActualizada == null)
            {
                return BadRequest("Datos de tarea vienen vacíos");
            }

            var response = await _tareasService.ActualizarTarea(id, tareaActualizada);

            if (response == false)
            {
                return NotFound("Tarea no encontrada en base de datos");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> EliminarTarea(Guid id)
        {
            var response = await _tareasService.EliminarTarea(id);
            if (response == false)
            {
                return NotFound("Tarea no encontrada en base de datos");
            }
            return NoContent();
        }
    }
}

