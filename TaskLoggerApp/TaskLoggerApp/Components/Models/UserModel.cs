using System.Collections.Generic;

namespace TaskLoggerApp.Components.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public UserRole Role { get; set; }
        public List<TaskModel> Tasks { get; set; }
        public List<GroupsModel> Groups { get; set; } // If a user can belong to multiple pools
    }
}
