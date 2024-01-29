using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskLoggerApi.Interfaces;
using TaskLoggerApi.Models.User;

namespace TaskLoggerApi.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserReturnDTO>>> GetUsers()
        {
            var user = await _userRepository.GetUsersAsync();

            var userToReturn = _mapper.Map<IEnumerable<UserReturnDTO>>(user);

            return Ok(userToReturn);
        }

        // GET: api/Users/5
        [HttpGet("{username}")]
        public async Task<ActionResult<UserReturnDTO>> GetUserByUsername(string username)
        {
            var user = await _userRepository.GetUserByUserNameAsync(username);

            var userToReturn = _mapper.Map<UserReturnDTO>(user);

            return Ok(userToReturn);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUser(UpdateUserDTO updateUser)
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var user = await _userRepository.GetUserByUserNameAsync(username);

            if (user == null) return NotFound();

            _mapper.Map(updateUser,user);

            if (await _userRepository.SaveAllAsync()) return NoContent();

            return BadRequest("User could not be updated");
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /*[HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UpdateUserDTO user)
        {
            
            var userToUpdate = await _userRepository.GetUserByIdAsync(id);

            if (userToUpdate == null) return NotFound();

            userToUpdate = _mapper.Map<AppUser>(user);

            bool res = await _userRepository.UpdateUserAsync(userToUpdate);

             if (!res) return NotFound();

            return Ok(user);
        }*/

        /*/ POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AppUser>> PostUser(AppUser user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.AppUserId }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/Users/count
        [HttpGet("count")]
        public async Task<ActionResult<int>> GetUserCount()
        {
            return await _context.Users.CountAsync();
        }


        // GET: api/Users/GroupCounts
        [HttpGet("GroupCounts")]
        public async Task<ActionResult<IEnumerable<GroupUserCount>>> GetUsersPerGroupCount()
        {
            var groupCounts = await _context.Groups
                .Select(g => new GroupUserCount
                {
                    GroupName = g.GroupsName,
                    UserCount = g.Users.Count
                })
                .ToListAsync();

            return groupCounts;
        }
        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.AppUserId == id);
        }*/


    }
}
