using Microsoft.AspNetCore.Mvc;
using SwimmingAcademy.API.DTOs;
using SwimmingAcademy.API.Interfaces;
using SwimmingAcademy.API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwimmingAcademy.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BranchController : ControllerBase
    {
        private readonly IBranchRepository _repo;

        public BranchController(IBranchRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BranchDto>>> GetBranches()
        {
            var branches = await _repo.GetBranchesAsync();
            return Ok(branches.Select(b => new BranchDto
            {
                MainId = b.MainId,
                SubId = b.SubId,
                Description = b.Description,
                Disabled = b.Disabled
            }));
        }

        [HttpGet("{mainId}/{subId}")]
        public async Task<ActionResult<BranchDto>> GetBranchById(short mainId, short subId)
        {
            var branch = await _repo.GetBranchByIdAsync(mainId, subId);
            if (branch == null) return NotFound();
            return Ok(new BranchDto
            {
                MainId = branch.MainId,
                SubId = branch.SubId,
                Description = branch.Description,
                Disabled = branch.Disabled
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(BranchDto dto)
        {
            var branch = new AppCode
            {
                MainId = dto.MainId,
                SubId = dto.SubId,
                Description = dto.Description,
                Disabled = dto.Disabled
            };
            await _repo.AddBranchAsync(branch);
            return Ok(dto);
        }

        [HttpPut("{mainId}/{subId}")]
        public async Task<IActionResult> Update(short mainId, short subId, BranchDto dto)
        {
            if (mainId != dto.MainId || subId != dto.SubId) return BadRequest();
            var branch = new AppCode
            {
                MainId = dto.MainId,
                SubId = dto.SubId,
                Description = dto.Description,
                Disabled = dto.Disabled
            };
            await _repo.UpdateBranchAsync(branch);
            return NoContent();
        }

        [HttpDelete("{mainId}/{subId}")]
        public async Task<IActionResult> Delete(short mainId, short subId)
        {
            await _repo.DeleteBranchAsync(mainId, subId);
            return NoContent();
        }
    }
}
