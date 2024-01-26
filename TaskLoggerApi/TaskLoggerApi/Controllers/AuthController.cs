using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using TaskLoggerApi.Data;
using TaskLoggerApi.Models.User;

namespace TaskLoggerApi.Controllers
{
    public class AuthController : BaseApiController
    {
        private readonly TaskLoggerDbContext _context;
        public AuthController(TaskLoggerDbContext context)
        {
            _context = context;
        }

        //POST: api/auth/register
        [HttpPost("register")]
        public async Task<ActionResult<AppUser>> Register(RegisterUserDTO registerUser)
        {
            if (await UserExists(registerUser.UserName.ToLower())) return BadRequest("Username already Exists");


            using var hmac = new HMACSHA512();

            var user = new AppUser
            {
                UserName = registerUser.UserName.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerUser.Password)),
                PasswordSalt = hmac.Key
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }

        [HttpPost("login")]

        public async Task<ActionResult<AppUser>> Login(UserLoginDTO userLoginDTO)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.UserName == userLoginDTO.UserName);

            if (user == null) return Unauthorized("Username incorrect");

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userLoginDTO.Password));

            for(int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Password incorrect");
            }

            return Ok(user);

        }
        private async Task<bool> UserExists(string username)
        {
            return await _context.Users.AnyAsync(x => x.UserName == username.ToLower());
        }

    }
}
