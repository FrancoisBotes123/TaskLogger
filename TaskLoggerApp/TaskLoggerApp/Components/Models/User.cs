using System.Collections.Generic;

namespace TaskLoggerApp.Components.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public UserRole Role { get; set; }
        public List<Tasks> Tasks { get; set; }
        public List<Groups> Groups { get; set; } // If a user can belong to multiple pools
    }
}
