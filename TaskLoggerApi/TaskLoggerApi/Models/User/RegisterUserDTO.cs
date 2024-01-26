using System.ComponentModel.DataAnnotations;

namespace TaskLoggerApi.Models.User
{
    public class RegisterUserDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
