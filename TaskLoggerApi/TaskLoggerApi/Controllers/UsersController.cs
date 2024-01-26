using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskLoggerApi.Data;
using TaskLoggerApi.HelperModels;
using TaskLoggerApi.Models.User;

namespace TaskLoggerApi.Controllers
{
    public class UsersController : BaseApiController
    {
        private readonly TaskLoggerDbContext _context;
        public UsersController(TaskLoggerDbContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, AppUser user)
        {
            if (id != user.AppUserId)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
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
        }


    }
}
