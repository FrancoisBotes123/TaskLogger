using TaskLoggerApi.Models.User;

namespace TaskLoggerApi.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
