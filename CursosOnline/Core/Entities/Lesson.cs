using System.ComponentModel.DataAnnotations;

namespace CursosOnline.Core.Entities
{
    /// <summary>
    /// Lección de un módulo. Pertenece a un módulo.
    /// </summary>
    public class Lesson
    {
        public int LessonId { get; set; }

        // Relación: Una lección pertenece a un módulo
        public int ModuleId { get; set; }
        public Module Module { get; set; } = null!;

        [Required]
        [StringLength(200)]
        public string Title { get; set; } = null!;

        [Required]
        public string Content { get; set; } = null!;

        [Required]
        public int OrderInModule { get; set; }
    }
} 