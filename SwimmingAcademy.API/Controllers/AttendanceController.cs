using Microsoft.AspNetCore.Mvc;
using SwimmingAcademy.API.Interfaces;
using SwimmingAcademy.API.Models;

namespace SwimmingAcademy.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceRepository _repo;

        public AttendanceController(IAttendanceRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Detail>>> GetAll() =>
            Ok(await _repo.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<Detail>> GetById(int id)
        {
            var attendance = await _repo.GetByIdAsync(id);
            return attendance is null ? NotFound() : Ok(attendance);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Detail attendance)
        {
            await _repo.AddAsync(attendance);
            return Ok(attendance);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Detail attendance)
        {
            if (id != attendance.SwimmerId) return BadRequest();
            await _repo.UpdateAsync(attendance);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repo.DeleteAsync(id);
            return NoContent();
        }
    }
}
