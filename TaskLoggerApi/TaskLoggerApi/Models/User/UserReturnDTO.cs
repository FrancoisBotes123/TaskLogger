namespace TaskLoggerApi.Models.User
{
    public class UserReturnDTO
    {
        public string UserName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime LastActvie { get; set; } = DateTime.UtcNow;
        public string  Token { get; set; }
        public UserRole Role { get; set; }
        public List<Tasks> Tasks { get; set; }
        public List<Groups> Groups { get; set; }
    }
}
