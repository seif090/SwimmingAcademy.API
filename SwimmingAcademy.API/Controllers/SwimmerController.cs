using Microsoft.AspNetCore.Mvc;
using SwimmingAcademy.API.Interfaces;
using SwimmingAcademy.API.Models;

namespace SwimmingAcademy.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SwimmerController : ControllerBase
    {
        private readonly ISwimmerRepository _repo;

        public SwimmerController(ISwimmerRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Info2>>> GetAll() =>
            Ok(await _repo.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<Info2>> GetById(int id)
        {
            var swimmer = await _repo.GetByIdAsync(id);
            return swimmer is null ? NotFound() : Ok(swimmer);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Info2 swimmer)
        {
            await _repo.AddAsync(swimmer);
            return Ok(swimmer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Info2 swimmer)
        {
            if (id != swimmer.SwimmerId) return BadRequest();
            await _repo.UpdateAsync(swimmer);
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
