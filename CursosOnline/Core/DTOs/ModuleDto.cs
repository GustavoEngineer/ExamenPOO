using System.ComponentModel.DataAnnotations;

namespace CursosOnline.Core.DTOs
{
    /// <summary>
    /// DTO para crear o actualizar un módulo.
    /// </summary>
    public class ModuleCreateUpdateDto
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El ID del curso debe ser mayor a 0")]
        public int CourseId { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; } = null!;

        [StringLength(1000)]
        public string? Description { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El orden debe ser mayor a 0")]
        public int OrderInCourse { get; set; }
    }

    /// <summary>
    /// DTO para mostrar información de un módulo.
    /// </summary>
    public class ModuleDto
    {
        public int ModuleId { get; set; }
        public int CourseId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public int OrderInCourse { get; set; }
    }
} 