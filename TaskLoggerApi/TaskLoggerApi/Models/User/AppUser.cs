using Microsoft.AspNetCore.Identity;

namespace TaskLoggerApi.Models.User
{
    public class AppUser
    {
        public int AppUserId { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public DateOnly DateOfBirth { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime LastActvie { get; set; } = DateTime.UtcNow;

        public UserRole Role { get; set; }
        public List<Tasks> Tasks { get; set; }
        public List<Groups> Groups { get; set; } // If a user can belong to multiple pools

    }
}
