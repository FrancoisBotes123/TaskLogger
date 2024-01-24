using System.Collections.Generic;

namespace TaskLoggerApi.Models
{

    public class Groups
    {
        public int GroupsId { get; set; }
        public string GroupName { get; set; }
        public int ManagerId { get; set; }
        public User Manager { get; set; }
        public List<User> Users { get; set; } // If a user can belong to multiple pools
    }
}
