using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaskLoggerApi.Interfaces;
using TaskLoggerApi.Models.Tasks;

namespace TaskLoggerApi.Data
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskLoggerDbContext _context;
        public TaskRepository(TaskLoggerDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Taskss>> GetAllTasksAsync()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<Taskss> GetTaskAsync(int id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        public async Task<IEnumerable<Taskss>> GetUserTasksAsync(int userId)
        {
            return await _context.Tasks
                .Where(u => u.UserId == userId)
                .ToListAsync();
        }

        public Task<Taskss> PostTasks(Taskss tasks)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveAllAsync()
        {
            throw new NotImplementedException();
        }

        public void UpdateTask(Taskss task)
        {
            _context.Entry(task).State = EntityState.Modified;
        }
    }
}
