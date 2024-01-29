using TaskLoggerApi.Models.User;

namespace TaskLoggerApi.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> UpdateUserAsync(AppUser user);

        Task<bool> SaveAllAsync();

        Task<IEnumerable<AppUser>> GetUsersAsync();

        Task<AppUser> GetUserByIdAsync(int id);

        Task<AppUser> GetUserByUserNameAsync(string username);


    }
}
