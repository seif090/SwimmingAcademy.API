using Microsoft.AspNetCore.Mvc;
using SwimmingAcademy.API.Interfaces;
using SwimmingAcademy.API.Models;

namespace SwimmingAcademy.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserTypeController : ControllerBase
    {
        private readonly IUserTypeRepository _repo;

        public UserTypeController(IUserTypeRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppCode>>> GetAll() =>
            Ok(await _repo.GetUserTypesAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<AppCode>> GetById(short mainId, short subId)
        {
            var type = await _repo.GetUserTypeByIdAsync(mainId, subId);
            return type is null ? NotFound() : Ok(type);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AppCode userType)
        {
            await _repo.AddUserTypeAsync(userType);
            return Ok(userType);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(short mainId, short subId, AppCode userType)
        {
            if (mainId != userType.MainId || subId != userType.SubId) return BadRequest();
            await _repo.UpdateUserTypeAsync(userType);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(short mainId, short subId)
        {
            await _repo.DeleteUserTypeAsync(mainId, subId);
            return NoContent();
        }
    }
}
