using System.ComponentModel.DataAnnotations;

namespace CursosOnline.Core.DTOs
{
    /// <summary>
    /// DTO para crear o actualizar una lección.
    /// </summary>
    public class LessonCreateUpdateDto
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El ID del módulo debe ser mayor a 0")]
        public int ModuleId { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; } = null!;

        [Required]
        public string Content { get; set; } = null!;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El orden debe ser mayor a 0")]
        public int OrderInModule { get; set; }
    }

    /// <summary>
    /// DTO para mostrar información de una lección.
    /// </summary>
    public class LessonDto
    {
        public int LessonId { get; set; }
        public int ModuleId { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public int OrderInModule { get; set; }
    }
} 