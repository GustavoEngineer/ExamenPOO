using CursosOnline.Core.Entities;
using CursosOnline.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using CursosOnline.Infrastructure.Data;

namespace CursosOnline.Infrastructure.Repositories
{
    public class ModuleRepository : IModuleRepository
    {
        private readonly CursosOnlineDbContext _context;

        public ModuleRepository(CursosOnlineDbContext context)
        {
            _context = context;
        }

        public Task AddAsync(Module module) => throw new System.NotImplementedException();
        public Task DeleteAsync(Module module) => throw new System.NotImplementedException();
        public async Task<IEnumerable<Module>> GetByCourseIdAsync(int courseId)
        {
            return await _context.Modules.Where(m => m.CourseId == courseId).ToListAsync();
        }
        public Task<Module?> GetByIdAsync(int moduleId) => throw new System.NotImplementedException();
        public Task UpdateAsync(Module module) => throw new System.NotImplementedException();

        public async Task<int> GetTotalCountAsync(string? filter = null)
        {
            var query = _context.Modules.AsQueryable();
            if (!string.IsNullOrEmpty(filter))
            {
                query = query.Where(m => m.Title.Contains(filter));
            }
            return await query.CountAsync();
        }
    }
} 