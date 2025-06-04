using Microsoft.AspNetCore.Mvc;
using SwimmingAcademy.API.DTOs;
using SwimmingAcademy.API.Interfaces;
using SwimmingAcademy.API.Models;
using SwimmingAcademy.API.Repositories;

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

        [HttpGet("by-branch/{branchSubId}")]
        public async Task<IActionResult> GetSwimmersByBranch(short branchSubId)
        {
            var swimmers = await _repo.GetSwimmersByBranchAsync(branchSubId);
            return Ok(swimmers);
        }

        [HttpGet("clubs")]
        public async Task<IActionResult> GetClubs()
        {
            var clubs = await _repo.GetClubsAsync();
            return Ok(clubs);
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetSwimmerList()
        {
            var swimmers = await _repo.GetSwimmerListAsync();
            return Ok(swimmers);
        }

        [HttpGet("{id}/info-tab")]
        public async Task<IActionResult> GetSwimmerInfoTab(int id)
        {
            var info = await _repo.GetSwimmerInfoTabAsync(id);
            if (info == null)
                return NotFound();
            return Ok(info);
        }

        [HttpGet("{id}/technical-tab")]
        public async Task<IActionResult> GetSwimmerTechnicalTab(long id)
        {
            var technical = await _repo.GetSwimmerTechnicalTabAsync(id);
            if (technical == null)
                return NotFound();
            return Ok(technical);
        }

        [HttpGet("{id}/log-tab")]
        public async Task<IActionResult> GetSwimmerLogTab(long id)
        {
            var logs = await _repo.GetSwimmerLogTabAsync(id);
            return Ok(logs);
        }

        [HttpPost("{id}/change-site")]
        public async Task<IActionResult> ChangeSwimmerSite(int id)
        {
            // Get the user's site from claims (adjust claim type as needed)
            var managerSiteClaim = User.FindFirst("Site");
            if (managerSiteClaim == null)
                return Forbid("Manager site information is missing.");

            short managerSite = short.Parse(managerSiteClaim.Value);

            // Get the swimmer from DB
            var swimmer = await _repo.GetByIdAsync(id);
            if (swimmer == null)
                return NotFound();

            // Only allow if swimmer is in a different site
            if (swimmer.Site == managerSite)
                return BadRequest("Swimmer is already in your site.");

            // Update swimmer's site
            swimmer.Site = managerSite;
            await _repo.UpdateAsync(swimmer);

            return Ok("Swimmer site updated successfully.");
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddSwimmer([FromBody] SwimmerCreateDto dto)
        {
            await _repo.AddSwimmerWithParentAsync(dto);
            return Ok("Swimmer and parent added successfully.");
        }

        [HttpPut("{id}/update-info")]
        public async Task<IActionResult> UpdateSwimmerInfo(long id, [FromBody] SwimmerUpdateDto dto)
        {
            // Get current user info from claims (adjust claim types as needed)
            var updatedByClaim = User.FindFirst("UserId");
            var updatedAtSiteClaim = User.FindFirst("Site");
            if (updatedByClaim == null || updatedAtSiteClaim == null)
                return Forbid("User or site information is missing.");

            int updatedBy = int.Parse(updatedByClaim.Value);
            short updatedAtSite = short.Parse(updatedAtSiteClaim.Value);

            var result = await _repo.UpdateSwimmerInfoAsync(id, dto, updatedBy, updatedAtSite);
            if (!result)
                return NotFound();

            return Ok("Swimmer info updated successfully.");
        }
    }
}
