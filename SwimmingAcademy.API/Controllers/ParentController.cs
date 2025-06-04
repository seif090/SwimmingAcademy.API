using Microsoft.AspNetCore.Mvc;
using SwimmingAcademy.API.Interfaces;
using SwimmingAcademy.API.Models;

namespace SwimmingAcademy.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParentController : ControllerBase
    {
        private readonly IParentRepository _repo;

        public ParentController(IParentRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Parent>>> GetAll() =>
            Ok(await _repo.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<Parent>> GetById(int id)
        {
            var parent = await _repo.GetByIdAsync(id);
            return parent is null ? NotFound() : Ok(parent);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Parent parent)
        {
            await _repo.AddAsync(parent);
            return Ok(parent);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Parent parent)
        {
            if (id != parent.SwimmerId) return BadRequest();
            await _repo.UpdateAsync(parent);
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
