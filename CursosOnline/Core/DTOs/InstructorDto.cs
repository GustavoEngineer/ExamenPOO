using System.ComponentModel.DataAnnotations;

namespace CursosOnline.Core.DTOs
{
    /// <summary>
    /// DTO para crear o actualizar un instructor.
    /// </summary>
    public class InstructorCreateUpdateDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;

        [Required]
        [EmailAddress]
        [StringLength(150)]
        public string Email { get; set; } = null!;
    }

    /// <summary>
    /// DTO para mostrar información de un instructor.
    /// </summary>
    public class InstructorDto
    {
        public int InstructorId { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
} 