using SwimmingAcademy.API.DTOs;
using SwimmingAcademy.API.Models;

namespace SwimmingAcademy.API.Interfaces
{
    public interface ILevelRepository
    {
        Task<IEnumerable<AppCode>> GetPreTeamLevelsAsync();
        Task<IEnumerable<AppCode>> GetSwimmerLevelsAsync();
        Task<AppCode?> GetLevelByIdAsync(short mainId, short subId);
        Task AddLevelAsync(AppCode level);
        Task UpdateLevelAsync(AppCode level);
        Task DeleteLevelAsync(short mainId, short subId);
    }
}
