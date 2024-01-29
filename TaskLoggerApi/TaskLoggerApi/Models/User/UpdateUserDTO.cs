namespace TaskLoggerApi.Models.User
{
    public class UpdateUserDTO
    {
        public DateTime LastActvie { get; set; } = DateTime.UtcNow;
        public UserRole Role { get; set; }
        public List<Groups> Groups { get; set; } 
    }
}
