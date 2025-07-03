using CursosOnline.Core.DTOs;
using CursosOnline.Core.Entities;
using CursosOnline.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CursosOnline.Application.Services
{
    public class ModuleService
    {
        private readonly IModuleRepository _moduleRepository;
        private readonly ICourseRepository _courseRepository;

        public ModuleService(IModuleRepository moduleRepository, ICourseRepository courseRepository)
        {
            _moduleRepository = moduleRepository;
            _courseRepository = courseRepository;
        }

        public async Task<IEnumerable<ModuleDto>> GetByCourseIdAsync(int courseId)
        {
            var modules = await _moduleRepository.GetByCourseIdAsync(courseId);
            var items = new List<ModuleDto>();
            foreach (var m in modules)
            {
                items.Add(new ModuleDto
                {
                    ModuleId = m.ModuleId,
                    CourseId = m.CourseId,
                    Title = m.Title,
                    Description = m.Description,
                    OrderInCourse = m.OrderInCourse
                });
            }
            return items;
        }

        public async Task<ModuleDto> CreateAsync(ModuleCreateUpdateDto dto)
        {
            // Regla: no modificar si el curso está publicado
            if (await _courseRepository.IsCoursePublishedAsync(dto.CourseId))
                throw new InvalidOperationException("No se puede agregar un módulo a un curso publicado.");
            var module = new Module
            {
                CourseId = dto.CourseId,
                Title = dto.Title,
                Description = dto.Description,
                OrderInCourse = dto.OrderInCourse
            };
            await _moduleRepository.AddAsync(module);
            return new ModuleDto
            {
                ModuleId = module.ModuleId,
                CourseId = module.CourseId,
                Title = module.Title,
                Description = module.Description,
                OrderInCourse = module.OrderInCourse
            };
        }

        public async Task<ModuleDto> UpdateAsync(int id, ModuleCreateUpdateDto dto)
        {
            var module = await _moduleRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException("Módulo no encontrado.");
            // Regla: no modificar si el curso está publicado
            if (await _courseRepository.IsCoursePublishedAsync(module.CourseId))
                throw new InvalidOperationException("No se puede modificar un módulo de un curso publicado.");
            module.Title = dto.Title;
            module.Description = dto.Description;
            module.OrderInCourse = dto.OrderInCourse;
            await _moduleRepository.UpdateAsync(module);
            return new ModuleDto
            {
                ModuleId = module.ModuleId,
                CourseId = module.CourseId,
                Title = module.Title,
                Description = module.Description,
                OrderInCourse = module.OrderInCourse
            };
        }

        public async Task DeleteAsync(int id)
        {
            var module = await _moduleRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException("Módulo no encontrado.");
            // Regla: no eliminar si el curso está publicado
            if (await _courseRepository.IsCoursePublishedAsync(module.CourseId))
                throw new InvalidOperationException("No se puede eliminar un módulo de un curso publicado.");
            await _moduleRepository.DeleteAsync(module);
        }
    }
} 