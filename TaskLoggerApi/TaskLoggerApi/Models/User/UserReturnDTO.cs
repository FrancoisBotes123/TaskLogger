namespace TaskLoggerApi.Models.User
{
    public class UserReturnDTO
    {
        public string UserName { get; set; }

        public string  Token { get; set; }
        public UserRole Role { get; set; }
        public List<Tasks> Tasks { get; set; }
        public List<Groups> Groups { get; set; }
    }
}
