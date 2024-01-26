using System.Collections.Generic;

namespace TaskLoggerApi.Models.User
{
    public class AppUser
    {
        public int AppUserId { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public UserRole Role { get; set; }
        public List<Tasks> Tasks { get; set; }
        public List<Groups> Groups { get; set; } // If a user can belong to multiple pools
    }
}
