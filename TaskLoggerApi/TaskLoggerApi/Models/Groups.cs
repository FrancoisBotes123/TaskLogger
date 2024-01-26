using System.Collections.Generic;
using TaskLoggerApi.Models.User;

namespace TaskLoggerApi.Models
{

    public class Groups
    {
        public int GroupsId { get; set; }
        public string GroupsName { get; set; }
        public int ManagerId { get; set; }
        public AppUser Manager { get; set; }
        public List<AppUser> Users { get; set; } // If a user can belong to multiple pools
    }
}
