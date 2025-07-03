using CursosOnline.Core.Entities;
using CursosOnline.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using CursosOnline.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CursosOnline.Infrastructure.Repositories
{
    public class InstructorRepository : IInstructorRepository
    {
        private readonly CursosOnlineDbContext _context;
        public InstructorRepository(CursosOnlineDbContext context)
        {
            _context = context;
        }
        public Task AddAsync(Instructor instructor) => throw new System.NotImplementedException();
        public Task DeleteAsync(Instructor instructor) => throw new System.NotImplementedException();
        public Task<bool> ExistsWithEmailAsync(string email) => throw new System.NotImplementedException();
        public Task<bool> ExistsWithNameAsync(string name) => throw new System.NotImplementedException();
        public async Task<IEnumerable<Instructor>> GetAllAsync(int page, int pageSize, string? filter = null)
        {
            var query = _context.Instructors.AsQueryable();

            if (!string.IsNullOrEmpty(filter))
            {
                query = query.Where(i => i.Name.Contains(filter));
            }

            return await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
        public Task<Instructor?> GetByIdAsync(int instructorId) => throw new System.NotImplementedException();
        public async Task<int> GetTotalCountAsync(string? filter = null)
        {
            var query = _context.Instructors.AsQueryable();
            if (!string.IsNullOrEmpty(filter))
            {
                query = query.Where(i => i.Name.Contains(filter));
            }
            return await query.CountAsync();
        }
        public Task<bool> HasPublishedCoursesAsync(int instructorId) => throw new System.NotImplementedException();
        public Task UpdateAsync(Instructor instructor) => throw new System.NotImplementedException();
    }
} 