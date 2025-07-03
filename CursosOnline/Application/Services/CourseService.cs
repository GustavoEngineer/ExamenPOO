using CursosOnline.Core.DTOs;
using CursosOnline.Core.Entities;
using CursosOnline.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CursosOnline.Application.Services
{
    public class CourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IInstructorRepository _instructorRepository;

        public CourseService(ICourseRepository courseRepository, IInstructorRepository instructorRepository)
        {
            _courseRepository = courseRepository;
            _instructorRepository = instructorRepository;
        }

        public async Task<PagedResultDto<CourseDto>> GetAllAsync(int page, int pageSize, string? filter = null)
        {
            var courses = await _courseRepository.GetAllAsync(page, pageSize, filter);
            var total = await _courseRepository.GetTotalCountAsync(filter);
            var items = new List<CourseDto>();
            foreach (var c in courses)
            {
                items.Add(new CourseDto
                {
                    CourseId = c.CourseId,
                    Title = c.Title,
                    Description = c.Description,
                    InstructorId = c.InstructorId,
                    InstructorName = c.Instructor?.Name ?? string.Empty,
                    IsPublished = c.IsPublished,
                    PublishedDate = c.PublishedDate
                });
            }
            return new PagedResultDto<CourseDto>
            {
                TotalItems = total,
                TotalPages = (int)Math.Ceiling((double)total / pageSize),
                Page = page,
                PageSize = pageSize,
                Items = items
            };
        }

        public async Task<CourseDto> CreateAsync(CourseCreateUpdateDto dto)
        {
            var instructor = await _instructorRepository.GetByIdAsync(dto.InstructorId) ?? throw new KeyNotFoundException("Instructor no encontrado.");
            var course = new Course
            {
                Title = dto.Title,
                Description = dto.Description,
                InstructorId = dto.InstructorId,
                Instructor = instructor
            };
            await _courseRepository.AddAsync(course);
            return new CourseDto
            {
                CourseId = course.CourseId,
                Title = course.Title,
                Description = course.Description,
                InstructorId = course.InstructorId,
                InstructorName = instructor.Name,
                IsPublished = course.IsPublished,
                PublishedDate = course.PublishedDate
            };
        }

        public async Task<CourseDto> UpdateAsync(int id, CourseCreateUpdateDto dto)
        {
            var course = await _courseRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException("Curso no encontrado.");
            // Regla: no modificar si publicado
            if (course.IsPublished)
                throw new InvalidOperationException("No se puede modificar un curso publicado.");
            course.Title = dto.Title;
            course.Description = dto.Description;
            course.InstructorId = dto.InstructorId;
            await _courseRepository.UpdateAsync(course);
            return new CourseDto
            {
                CourseId = course.CourseId,
                Title = course.Title,
                Description = course.Description,
                InstructorId = course.InstructorId,
                InstructorName = course.Instructor?.Name ?? string.Empty,
                IsPublished = course.IsPublished,
                PublishedDate = course.PublishedDate
            };
        }

        public async Task DeleteAsync(int id)
        {
            var course = await _courseRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException("Curso no encontrado.");
            // Regla: no eliminar si publicado
            if (course.IsPublished)
                throw new InvalidOperationException("No se puede eliminar un curso publicado.");
            await _courseRepository.DeleteAsync(course);
        }

        public async Task<CourseDto> PublishAsync(int id)
        {
            var course = await _courseRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException("Curso no encontrado.");
            if (course.IsPublished)
                throw new InvalidOperationException("El curso ya está publicado.");
            course.IsPublished = true;
            course.PublishedDate = DateTime.UtcNow;
            await _courseRepository.UpdateAsync(course);
            return new CourseDto
            {
                CourseId = course.CourseId,
                Title = course.Title,
                Description = course.Description,
                InstructorId = course.InstructorId,
                InstructorName = course.Instructor?.Name ?? string.Empty,
                IsPublished = course.IsPublished,
                PublishedDate = course.PublishedDate
            };
        }
    }
} 