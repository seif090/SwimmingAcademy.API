using SwimmingAcademy.API.Models;

namespace SwimmingAcademy.API.Interfaces
{
    public interface ISwimmerRepository
    {
        Task<IEnumerable<Info2>> GetAllAsync();
        Task<Info2?> GetByIdAsync(int id);
        Task AddAsync(Info2 swimmer);
        Task UpdateAsync(Info2 swimmer);
        Task DeleteAsync(int id);
    }
}
