using SwimmingAcademy.API.DTOs;
using SwimmingAcademy.API.Models;
using System.Threading.Tasks;

namespace SwimmingAcademy.API.Interfaces
{
    public interface ISwimmerRepository
    {
        Task<IEnumerable<Info2>> GetAllAsync();
        Task<Info2?> GetByIdAsync(int id);
        Task AddAsync(Info2 swimmer);
        Task UpdateAsync(Info2 swimmer);
        Task DeleteAsync(int id);
        Task<IEnumerable<Info2>> GetSwimmersByBranchAsync(short branchSubId);
        Task<List<ClubDto>> GetClubsAsync();
        Task<List<SwimmerListDto>> GetSwimmerListAsync();
        Task<SwimmerTechnicalTabDto?> GetSwimmerTechnicalTabAsync(long swimmerId);
        Task<SwimmerInfoTabDto?> GetSwimmerInfoTabAsync(int swimmerId);
        Task AddSwimmerWithParentAsync(SwimmerCreateDto dto);
        Task<List<SwimmerLogTabDto>> GetSwimmerLogTabAsync(long swimmerId);
        Task<bool> UpdateSwimmerInfoAsync(long swimmerId, SwimmerUpdateDto dto, int updatedBy, short updatedAtSite);
        Task<User?> GetUserByIdAsync(int id);
        Task<AppCode?> GetSiteBySubIdAsync(short subId);
        Task<bool> RemoveSwimmerFromBranchAsync(int userId, long swimmerId);
    }
}
