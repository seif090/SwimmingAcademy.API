using Microsoft.AspNetCore.Mvc;
using SwimmingAcademy.API.DTOs;
using SwimmingAcademy.API.Interfaces;
using SwimmingAcademy.API.Models;

namespace SwimmingAcademy.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LevelController : ControllerBase
    {
        private readonly ILevelRepository _repo;

        public LevelController(ILevelRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("preteam")]
        public async Task<ActionResult<IEnumerable<LevelDto>>> GetPreTeamLevels()
        {
            var levels = await _repo.GetPreTeamLevelsAsync();
            return Ok(levels.Select(l => new LevelDto
            {
                MainId = l.MainId,
                SubId = l.SubId,
                Description = l.Description,
                Disabled = l.Disabled
            }));
        }

        [HttpGet("swimmer")]
        public async Task<ActionResult<IEnumerable<LevelDto>>> GetSwimmerLevels()
        {
            var levels = await _repo.GetSwimmerLevelsAsync();
            return Ok(levels.Select(l => new LevelDto
            {
                MainId = l.MainId,
                SubId = l.SubId,
                Description = l.Description,
                Disabled = l.Disabled
            }));
        }

        [HttpGet("{mainId}/{subId}")]
        public async Task<ActionResult<LevelDto>> GetLevelById(short mainId, short subId)
        {
            var level = await _repo.GetLevelByIdAsync(mainId, subId);
            if (level == null) return NotFound();
            return Ok(new LevelDto
            {
                MainId = level.MainId,
                SubId = level.SubId,
                Description = level.Description,
                Disabled = level.Disabled
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(LevelDto dto)
        {
            var level = new AppCode
            {
                MainId = dto.MainId,
                SubId = dto.SubId,
                Description = dto.Description,
                Disabled = dto.Disabled
            };
            await _repo.AddLevelAsync(level);
            return Ok(dto);
        }

        [HttpPut("{mainId}/{subId}")]
        public async Task<IActionResult> Update(short mainId, short subId, LevelDto dto)
        {
            if (mainId != dto.MainId || subId != dto.SubId) return BadRequest();
            var level = new AppCode
            {
                MainId = dto.MainId,
                SubId = dto.SubId,
                Description = dto.Description,
                Disabled = dto.Disabled
            };
            await _repo.UpdateLevelAsync(level);
            return NoContent();
        }

        [HttpDelete("{mainId}/{subId}")]
        public async Task<IActionResult> Delete(short mainId, short subId)
        {
            await _repo.DeleteLevelAsync(mainId, subId);
            return NoContent();
        }
    }
}
