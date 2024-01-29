using System;
using TaskLoggerApi.Models.User;

namespace TaskLoggerApi.Models.Tasks
{
    public class Taskss
    {
        public int TasksId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UserId { get; set; }
        public AppUser User { get; set; }
    }
}
