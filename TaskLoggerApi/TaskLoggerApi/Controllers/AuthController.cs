using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using TaskLoggerApi.Data;
using TaskLoggerApi.Interfaces;
using TaskLoggerApi.Models.User;

namespace TaskLoggerApi.Controllers
{
    public class AuthController : BaseApiController
    {
        private readonly TaskLoggerDbContext _context;
        private readonly ITokenService _tokenService;

        public AuthController(TaskLoggerDbContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        //POST: api/auth/register
        [HttpPost("register")]
        public async Task<ActionResult<UserReturnDTO>> Register(RegisterUserDTO registerUser)
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

            return Ok(new UserReturnDTO
            {
                UserName = user.UserName,
                Token=_tokenService.CreateToken(user),
                Role = user.Role,
                Groups = user.Groups,
                Tasks = user.Tasks,
            });
        }

        [HttpPost("login")]

        public async Task<ActionResult<UserReturnDTO>> Login(UserLoginDTO userLoginDTO)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.UserName == userLoginDTO.UserName);

            if (user == null) return Unauthorized("Username incorrect");

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userLoginDTO.Password));

            for(int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Password incorrect");
            }

            return Ok(new UserReturnDTO
            {
                UserName = user.UserName,
                Token = _tokenService.CreateToken(user),
                Role = user.Role,
                Groups = user.Groups,
                Tasks = user.Tasks,
            });

        }
        private async Task<bool> UserExists(string username)
        {
            return await _context.Users.AnyAsync(x => x.UserName == username.ToLower());
        }

    }
}
