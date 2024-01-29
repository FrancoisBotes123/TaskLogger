using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskLoggerApi.Data;
using TaskLoggerApi.Interfaces;
using TaskLoggerApi.Models.Tasks;
using TaskLoggerApi.Models.User;

namespace TaskLoggerApi.Controllers
{
    [Authorize]
    public class TasksController : BaseApiController
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IUserRepository _userRepository;

        private readonly IMapper _mapper;

        public TasksController(ITaskRepository taskRepository,IUserRepository userRepository,IMapper mapper)
        {
            _taskRepository = taskRepository;
            _userRepository = userRepository;
            _mapper = mapper;

        }

        // GET: api/Tasks
        [HttpGet]
        public async Task<IEnumerable<Taskss>> GetTasks()
        {
            return await _taskRepository.GetAllTasksAsync();
        }

        // GET: api/Tasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Taskss>> GetTasks(int id)
        {
            var tasks = await _taskRepository.GetTaskAsync(id);

            if (tasks == null)
            {
                return NotFound();
            }

            return tasks;
        }

        [HttpGet("user-tasks/{username}")]
        public async Task<ActionResult<Taskss>> GetUserTasks(string username)
        {
            var usernameFromClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (usernameFromClaim == null || usernameFromClaim != username) return BadRequest();

            var user = await _userRepository.GetUserByUserNameAsync(username);

            if (user == null) return NotFound();

            var userTasks = _taskRepository.GetUserTasksAsync(user.Id);

            if (userTasks == null) return NotFound();

            return Ok(userTasks);
        }

        // PUT: api/Tasks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTasks(UpdateTaskDTO updateTask)
        {
            if(updateTask == null) return BadRequest();

            //_mapper.Map(updateTask)

            return Ok(updateTask);
        }

        // POST: api/Tasks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /*[HttpPost]
        public async Task<ActionResult<Taskss>> PostTasks(Taskss tasks)
        {
            _context.Tasks.Add(tasks);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTasks", new { id = tasks.TasksId }, tasks);
        }*/

        // DELETE: api/Tasks/5
       /* [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTasks(int id)
        {
            var tasks = await _context.Tasks.FindAsync(id);
            if (tasks == null)
            {
                return NotFound();
            }

            _context.Tasks.Remove(tasks);
            await _context.SaveChangesAsync();

            return NoContent();
        }*/

        /*private bool TasksExists(int id)
        {
            return _context.Tasks.Any(e => e.TasksId == id);
        }*/
    }
}
