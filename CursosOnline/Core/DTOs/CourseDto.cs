using System.ComponentModel.DataAnnotations;

namespace CursosOnline.Core.DTOs
{
    /// <summary>
    /// DTO para crear o actualizar un curso.
    /// </summary>
    public class CourseCreateUpdateDto
    {
        [Required]
        [StringLength(200)]
        public string Title { get; set; } = null!;

        [StringLength(1000)]
        public string? Description { get; set; }

        [Required]
        public int InstructorId { get; set; }
    }

    /// <summary>
    /// DTO para mostrar información de un curso.
    /// </summary>
    public class CourseDto
    {
        public int CourseId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public int InstructorId { get; set; }
        public string InstructorName { get; set; } = null!;
        public bool IsPublished { get; set; }
        public DateTime? PublishedDate { get; set; }
    }
} 