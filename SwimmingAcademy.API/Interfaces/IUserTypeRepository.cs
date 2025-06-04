using SwimmingAcademy.API.Models;

namespace SwimmingAcademy.API.Interfaces
{
    public interface IUserTypeRepository
    {
        Task<IEnumerable<AppCode>> GetUserTypesAsync();
        Task<AppCode?> GetUserTypeByIdAsync(short mainId, short subId);
        Task AddUserTypeAsync(AppCode userType);
        Task UpdateUserTypeAsync(AppCode userType);
        Task DeleteUserTypeAsync(short mainId, short subId);
    }
}
