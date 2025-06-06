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

        [HttpPost("change-site")]
        public async Task<IActionResult> ChangeSwimmerSite([FromQuery] int userId, [FromQuery] long swimmerId)
        {
            // Get the user from DB
            var user = await _repo.GetUserByIdAsync(userId);
            if (user == null)
                return NotFound("User not found.");

            // Get the user's site from AppCodes table using SubId
            var userSite = await _repo.GetSiteBySubIdAsync(user.Site);
            if (userSite == null)
                return NotFound("User's site not found.");

            // Get the swimmer from DB
            var swimmer = await _repo.GetByIdAsync((int)swimmerId);
            if (swimmer == null)
                return NotFound("Swimmer not found.");

            // Get the swimmer's site from AppCodes table using SubId
            var swimmerSite = await _repo.GetSiteBySubIdAsync(swimmer.Site);
            if (swimmerSite == null)
                return NotFound("Swimmer's site not found.");

            // Only allow if swimmer is in a different site
            if (swimmer.Site == user.Site)
                return BadRequest("Swimmer is already in your site.");

            // Update swimmer's site to user's site (SubId)
            swimmer.Site = user.Site;
            await _repo.UpdateAsync(swimmer);

            return Ok($"Swimmer site updated successfully to {userSite.Description}.");
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

        [HttpDelete("remove")]
        public async Task<IActionResult> RemoveSwimmer([FromQuery] int userId, [FromQuery] long swimmerId)
        {
            // Get the user from DB
            var user = await _repo.GetUserByIdAsync(userId);
            if (user == null)
                return NotFound("User not found.");

            // Get the swimmer from DB
            var swimmer = await _repo.GetByIdAsync((int)swimmerId);
            if (swimmer == null)
                return NotFound("Swimmer not found.");

            // Only allow if swimmer is in the same site/branch as the user
            if (swimmer.Site != user.Site)
                return Forbid("You can only remove swimmers from your own branch.");

            // Remove swimmer
            await _repo.DeleteAsync((int)swimmerId);

            return Ok("Swimmer removed successfully.");
        }
    }
}
