using SwimmingAcademy.API.Models;

namespace SwimmingAcademy.API.Interfaces
{
    public interface IAttendanceRepository
    {
        Task<IEnumerable<Detail>> GetAllAsync();
        Task<Detail?> GetByIdAsync(int id);
        Task AddAsync(Detail attendance);
        Task UpdateAsync(Detail attendance);
        Task DeleteAsync(int id);
    }
}
