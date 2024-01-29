using Microsoft.EntityFrameworkCore;
using TaskLoggerApi.Interfaces;
using TaskLoggerApi.Models.User;

namespace TaskLoggerApi.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly TaskLoggerDbContext _context;
        public UserRepository(TaskLoggerDbContext context)
        {
            _context = context;
        }
        public async Task<AppUser> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<AppUser> GetUserByUserNameAsync(string username)
        {
            return await _context.Users
                .Include(u => u.Tasks)
                .Include(u => u.Groups)
                .SingleOrDefaultAsync(u => u.UserName == username);
        }

        public async Task<IEnumerable<AppUser>> GetUsersAsync()
        {
            return await _context.Users
                .Include(u => u.Tasks)
                .Include(u => u.Groups)
                .ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void UpdateUser(AppUser user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }

    }
}
