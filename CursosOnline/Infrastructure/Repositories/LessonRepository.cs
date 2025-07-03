using CursosOnline.Core.Entities;
using CursosOnline.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using CursosOnline.Infrastructure.Data;

namespace CursosOnline.Infrastructure.Repositories
{
    public class LessonRepository : ILessonRepository
    {
        private readonly CursosOnlineDbContext _context;

        public LessonRepository(CursosOnlineDbContext context)
        {
            _context = context;
        }

        public Task AddAsync(Lesson lesson) => throw new System.NotImplementedException();
        public Task DeleteAsync(Lesson lesson) => throw new System.NotImplementedException();
        public async Task<IEnumerable<Lesson>> GetByModuleIdAsync(int moduleId)
        {
            return await _context.Lessons.Where(l => l.ModuleId == moduleId).ToListAsync();
        }
        public Task<Lesson?> GetByIdAsync(int lessonId) => throw new System.NotImplementedException();
        public Task UpdateAsync(Lesson lesson) => throw new System.NotImplementedException();

        public async Task<int> GetTotalCountAsync(string? filter = null)
        {
            var query = _context.Lessons.AsQueryable();
            if (!string.IsNullOrEmpty(filter))
            {
                query = query.Where(l => l.Title.Contains(filter));
            }
            return await query.CountAsync();
        }
    }
} 