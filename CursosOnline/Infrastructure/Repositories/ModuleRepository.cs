using CursosOnline.Core.Entities;
using CursosOnline.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CursosOnline.Infrastructure.Repositories
{
    public class ModuleRepository : IModuleRepository
    {
        public Task AddAsync(Module module) => throw new System.NotImplementedException();
        public Task DeleteAsync(Module module) => throw new System.NotImplementedException();
        public Task<IEnumerable<Module>> GetByCourseIdAsync(int courseId) => throw new System.NotImplementedException();
        public Task<Module?> GetByIdAsync(int moduleId) => throw new System.NotImplementedException();
        public Task UpdateAsync(Module module) => throw new System.NotImplementedException();
    }
} 