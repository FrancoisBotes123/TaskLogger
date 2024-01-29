using Microsoft.AspNetCore.Identity;

namespace TaskLoggerApi.Models.User
{
    public class AppUser: IdentityUser<int>
    {
        public DateOnly DateOfBirth { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime LastActvie { get; set; } = DateTime.UtcNow;

        public ICollection<UserRole> Roles { get; set; }
        public List<Tasks> Tasks { get; set; }
        public List<Groups> Groups { get; set; } // If a user can belong to multiple pools

    }
}
