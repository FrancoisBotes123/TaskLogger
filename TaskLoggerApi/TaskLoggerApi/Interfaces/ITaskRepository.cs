using TaskLoggerApi.Models.Tasks;

namespace TaskLoggerApi.Interfaces
{
    public interface ITaskRepository
    {
        void UpdateTask(Taskss task);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<Taskss>> GetAllTasksAsync();
        Task<IEnumerable<Taskss>> GetUserTasksAsync(int userId);
        Task<Taskss> GetTaskAsync(int id);

        Task<Taskss> PostTasks(Taskss tasks);
    }
}
