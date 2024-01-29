using System.Collections.Generic;

namespace TaskLoggerApp.Components.Models
{

    public class GroupsModel
    {
        public int GroupsId { get; set; }
        public string GroupsName { get; set; }
        public int ManagerId { get; set; }
        public UserModel Manager { get; set; }
        public List<UserModel> Users { get; set; } // If a user can belong to multiple pools
    }
}
