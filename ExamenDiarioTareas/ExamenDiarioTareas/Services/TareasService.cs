using ExamenDiarioTareas.Data;
using ExamenDiarioTareas.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamenDiarioTareas.Services
{
    public class TareasService
    {
        private readonly DataContext _context;

        public TareasService(DataContext context)
        {
            _context = context;
        }

        // Obtener todas las tareas
        public async Task<List<Tarea>> ObtenerTareas()
        {
            return await _context.Tarea.ToListAsync();
        }

        // Obtener una tarea por ID
        public async Task<Tarea?> ObtenerTareaPorId(Guid id)
        {
            return await _context.Tarea.FirstOrDefaultAsync(t => t.Id == id);
        }

        // Crear una nueva tarea
        public async Task<Tarea> CrearTarea(Tarea tarea)
        {
            tarea.Id = Guid.NewGuid();


            _context.Tarea.Add(tarea);
            await _context.SaveChangesAsync();

            return tarea;
        }

        // Actualizar una tarea existente
        public async Task<bool> ActualizarTarea(Guid id, Tarea tareaActualizada)
        {
            var tarea = await _context.Tarea.FindAsync(id);
            if (tarea == null) return false;

            // tarea.Titulo = tareaActualizada.Titulo;
            tarea.Descripcion = tareaActualizada.Descripcion;
            //tarea.Estado = tareaActualizada.Estado;

            await _context.SaveChangesAsync();
            return true;
        }

        // Eliminar una tarea
        public async Task<bool> EliminarTarea(Guid id)
        {
            var tarea = await _context.Tarea.FindAsync(id);
            if (tarea == null) return false;

            _context.Tarea.Remove(tarea);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

