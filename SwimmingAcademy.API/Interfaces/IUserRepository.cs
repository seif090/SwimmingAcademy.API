using SwimmingAcademy.API.DTOs;
using SwimmingAcademy.API.Models;
using SwimmingAcademy.API.Repositories;

namespace SwimmingAcademy.API.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User?> GetUserByIdAsync(int id);
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
        Task<List<string>> GetBranchNamesForUserTypeAsync(short userTypeId);
        Task<User?> AuthenticateAsync(string userName, string password);
        Task<LoginResultDto?> LoginAsync(int UserId, string password);
        Task<UserLoginDetailDto?> LoginWithActionsAsync(int UserId,  string password);
        Task<List<UserActionDto>> GetAllowedActionsForUserOnSwimmerAsync(int userId, long swimmerId);
    }
}

