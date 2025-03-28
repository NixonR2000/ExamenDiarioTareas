using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ExamenDiarioTareas.Models
{
    public class Tarea
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("decripcion")]
        public string Descripcion { get; set; }
    }
}
