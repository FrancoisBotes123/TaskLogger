using System;

namespace TaskLoggerApp.Components.Models
{
    public class TaskModel
    {
        public int TasksId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UserId { get; set; }
        public UserModel User { get; set; }
    }
}
