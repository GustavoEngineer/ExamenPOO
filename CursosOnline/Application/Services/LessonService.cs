using CursosOnline.Core.DTOs;
using CursosOnline.Core.Entities;
using CursosOnline.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CursosOnline.Application.Services
{
    public class LessonService
    {
        private readonly ILessonRepository _lessonRepository;
        private readonly IModuleRepository _moduleRepository;
        private readonly ICourseRepository _courseRepository;

        public LessonService(ILessonRepository lessonRepository, IModuleRepository moduleRepository, ICourseRepository courseRepository)
        {
            _lessonRepository = lessonRepository;
            _moduleRepository = moduleRepository;
            _courseRepository = courseRepository;
        }

        public async Task<IEnumerable<LessonDto>> GetByModuleIdAsync(int moduleId)
        {
            var lessons = await _lessonRepository.GetByModuleIdAsync(moduleId);
            var items = new List<LessonDto>();
            foreach (var l in lessons)
            {
                items.Add(new LessonDto
                {
                    LessonId = l.LessonId,
                    ModuleId = l.ModuleId,
                    Title = l.Title,
                    Content = l.Content,
                    OrderInModule = l.OrderInModule
                });
            }
            return items;
        }

        public async Task<LessonDto> CreateAsync(LessonCreateUpdateDto dto)
        {
            var module = await _moduleRepository.GetByIdAsync(dto.ModuleId) ?? throw new KeyNotFoundException("Módulo no encontrado.");
            // Regla: no modificar si el curso está publicado
            if (await _courseRepository.IsCoursePublishedAsync(module.CourseId))
                throw new InvalidOperationException("No se puede agregar una lección a un curso publicado.");
            var lesson = new Lesson
            {
                ModuleId = dto.ModuleId,
                Title = dto.Title,
                Content = dto.Content,
                OrderInModule = dto.OrderInModule
            };
            await _lessonRepository.AddAsync(lesson);
            return new LessonDto
            {
                LessonId = lesson.LessonId,
                ModuleId = lesson.ModuleId,
                Title = lesson.Title,
                Content = lesson.Content,
                OrderInModule = lesson.OrderInModule
            };
        }

        public async Task<LessonDto> UpdateAsync(int id, LessonCreateUpdateDto dto)
        {
            var lesson = await _lessonRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException("Lección no encontrada.");
            var module = await _moduleRepository.GetByIdAsync(lesson.ModuleId) ?? throw new KeyNotFoundException("Módulo no encontrado.");
            // Regla: no modificar si el curso está publicado
            if (await _courseRepository.IsCoursePublishedAsync(module.CourseId))
                throw new InvalidOperationException("No se puede modificar una lección de un curso publicado.");
            lesson.Title = dto.Title;
            lesson.Content = dto.Content;
            lesson.OrderInModule = dto.OrderInModule;
            await _lessonRepository.UpdateAsync(lesson);
            return new LessonDto
            {
                LessonId = lesson.LessonId,
                ModuleId = lesson.ModuleId,
                Title = lesson.Title,
                Content = lesson.Content,
                OrderInModule = lesson.OrderInModule
            };
        }

        public async Task DeleteAsync(int id)
        {
            var lesson = await _lessonRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException("Lección no encontrada.");
            var module = await _moduleRepository.GetByIdAsync(lesson.ModuleId) ?? throw new KeyNotFoundException("Módulo no encontrado.");
            // Regla: no eliminar si el curso está publicado
            if (await _courseRepository.IsCoursePublishedAsync(module.CourseId))
                throw new InvalidOperationException("No se puede eliminar una lección de un curso publicado.");
            await _lessonRepository.DeleteAsync(lesson);
        }
    }
} 