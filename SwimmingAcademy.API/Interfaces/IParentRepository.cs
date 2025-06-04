using SwimmingAcademy.API.Models;

namespace SwimmingAcademy.API.Interfaces
{
    public interface IParentRepository
    {
        Task<IEnumerable<Parent>> GetAllAsync();
        Task<Parent?> GetByIdAsync(int id);
        Task AddAsync(Parent parent);
        Task UpdateAsync(Parent parent);
        Task DeleteAsync(int id);
    }
}
