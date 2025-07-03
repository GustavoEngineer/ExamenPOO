using CursosOnline.Core.Entities;
using CursosOnline.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CursosOnline.Infrastructure.Repositories
{
    public class LessonRepository : ILessonRepository
    {
        public Task AddAsync(Lesson lesson) => throw new System.NotImplementedException();
        public Task DeleteAsync(Lesson lesson) => throw new System.NotImplementedException();
        public Task<IEnumerable<Lesson>> GetByModuleIdAsync(int moduleId) => throw new System.NotImplementedException();
        public Task<Lesson?> GetByIdAsync(int lessonId) => throw new System.NotImplementedException();
        public Task UpdateAsync(Lesson lesson) => throw new System.NotImplementedException();
    }
} 