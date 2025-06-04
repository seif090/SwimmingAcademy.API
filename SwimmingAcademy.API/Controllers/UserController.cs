using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SwimmingAcademy.API.DTOs;
using SwimmingAcademy.API.Helpers;
using SwimmingAcademy.API.Interfaces;
using SwimmingAcademy.API.Models;
using SwimmingAcademy.API.Repositories;
using System.Threading.Tasks;

namespace SwimmingAcademy.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repo;
        private readonly IConfiguration _config;

        public UserController(IUserRepository repo, IConfiguration config)
        {
            _repo = repo;
            _config = config;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            var users = await _repo.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(int id)
        {
            var user = await _repo.GetUserByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            await _repo.AddUserAsync(user);
            return CreatedAtAction(nameof(GetById), new { id = user.Userid }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, User user)
        {
            if (id != user.Userid) return BadRequest();
            await _repo.UpdateUserAsync(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repo.DeleteUserAsync(id);
            return NoContent();
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto request)
        {
            var result = await _repo.LoginWithActionsAsync(request.UserId, request.Password);
            if (result == null)
                return Unauthorized("Invalid credentials.");

            return Ok(result);
        }

        [HttpGet("allowed-actions/{userId}")]
        public async Task<IActionResult> GetAllowedActionsForUser(int userId)
        {
            var actions = await _repo.GetAllowedActionsForUserAsync(userId);
            return Ok(actions);
        }
    }
}
