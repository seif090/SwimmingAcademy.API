using SwimmingAcademy.API.Models;

namespace SwimmingAcademy.API.Interfaces
{
    public interface IBranchRepository
    {
        Task<IEnumerable<AppCode>> GetBranchesAsync();
        Task<AppCode?> GetBranchByIdAsync(short mainId, short subId);
        Task AddBranchAsync(AppCode branch);
        Task UpdateBranchAsync(AppCode branch);
        Task DeleteBranchAsync(short mainId, short subId);
    }
}
