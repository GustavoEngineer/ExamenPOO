using CursosOnline.Core.Entities;
using CursosOnline.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CursosOnline.Infrastructure.Repositories
{
    public class InstructorRepository : IInstructorRepository
    {
        public Task AddAsync(Instructor instructor) => throw new System.NotImplementedException();
        public Task DeleteAsync(Instructor instructor) => throw new System.NotImplementedException();
        public Task<bool> ExistsWithEmailAsync(string email) => throw new System.NotImplementedException();
        public Task<bool> ExistsWithNameAsync(string name) => throw new System.NotImplementedException();
        public Task<IEnumerable<Instructor>> GetAllAsync(int page, int pageSize, string? filter = null) => throw new System.NotImplementedException();
        public Task<Instructor?> GetByIdAsync(int instructorId) => throw new System.NotImplementedException();
        public Task<int> GetTotalCountAsync(string? filter = null) => throw new System.NotImplementedException();
        public Task<bool> HasPublishedCoursesAsync(int instructorId) => throw new System.NotImplementedException();
        public Task UpdateAsync(Instructor instructor) => throw new System.NotImplementedException();
    }
} 