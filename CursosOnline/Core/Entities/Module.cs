using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CursosOnline.Core.Entities
{
    /// <summary>
    /// Módulo de un curso. Pertenece a un curso y contiene lecciones.
    /// </summary>
    public class Module
    {
        public int ModuleId { get; set; }

        // Relación: Un módulo pertenece a un curso
        public int CourseId { get; set; }
        public Course Course { get; set; } = null!;

        [Required]
        [StringLength(200)]
        public string Title { get; set; } = null!;

        [StringLength(1000)]
        public string? Description { get; set; }

        [Required]
        public int OrderInCourse { get; set; }

        // Relación: Un módulo tiene muchas lecciones
        public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
    }
} 