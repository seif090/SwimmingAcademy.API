using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using SwimmingAcademy.API.DTOs;
using SwimmingAcademy.API.Interfaces;
using SwimmingAcademy.API.Models;

namespace SwimmingAcademy.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SwimminAcadmyContext _context;

        public UserRepository(SwimminAcadmyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<User?> AuthenticateAsync(string userName, string password)
        {
            var user = await _context.Users
                .Include(u => u.UserType)
                .FirstOrDefaultAsync(u => u.Fullname == userName && !u.Disabled);

            if (user == null)
                return null;

            // Verify hashed password
            if (!BCrypt.Net.BCrypt.Verify(password, user.Password))
                return null;

            return user;
        }

        public async Task<List<string>> GetBranchNamesForUserTypeAsync(short userTypeId)
        {
            var actionIds = await _context.UsersPrivs
                .Where(up => up.UserTypeId == userTypeId)
                .Select(up => up.ActionId)
                .ToListAsync();

            var branchActionNames = await _context.Actions
                .Where(a => actionIds.Contains(a.ActionId) && a.Module == "Branch" && !a.Disabled)
                .Select(a => a.ActionName)
                .ToListAsync();

            var branchNames = await _context.AppCodes
                .Where(ac => ac.SubId >= 1 && branchActionNames.Contains(ac.Description) && !ac.Disabled)
                .Select(ac => ac.Description)
                .ToListAsync();

            return branchNames;
        }

        public async Task<LoginResultDto?> LoginAsync(int UserId, string password)
        {
            var user = await _context.Users
                .Include(u => u.SiteNavigation)
                .Include(u => u.UserType)
                .FirstOrDefaultAsync(u => u.Userid == UserId && !u.Disabled);

            if (user == null)
                return null;

            if(user.Password != password)
                return null;
            return new LoginResultDto
            {
                FullName = user.Fullname,
                SiteSubId = user.SiteNavigation?.SubId ?? 0,
                SiteDescription = user.SiteNavigation?.Description ?? string.Empty,
                UserTypeSubId = user.UserType?.SubId ?? 0,
                UserTypeDescription = user.UserType?.Description ?? string.Empty
            };
        }
        public async Task<UserLoginDetailDto?> LoginWithActionsAsync(int UserId, string password)
        {
            var user = await _context.Users
                .Include(u => u.SiteNavigation)
                .Include(u => u.UserType)
                .FirstOrDefaultAsync(u => u.Userid == UserId && !u.Disabled);

            if (user == null)
                return null;

            // Use BCrypt for password verification
            if (user.Password != password)
                return null;

            // Get all action IDs allowed for this user's UserType
            var actionIds = await _context.UsersPrivs
                .Where(up => up.UserTypeId == user.UserTypeId)
                .Select(up => up.ActionId)
                .ToListAsync();

            // Get the allowed actions with their names and modules
            var actions = await _context.Actions
                .Where(a => actionIds.Contains(a.ActionId) && !a.Disabled)
                .Select(a => new UserActionDto
                {
                    ActionId = a.ActionId,
                    ActionName = a.ActionName,
                    Module = a.Module
                })
                .ToListAsync();

            return new UserLoginDetailDto
            {
                FullName = user.Fullname,
                SiteSubId = user.SiteNavigation?.SubId ?? 0,
                SiteDescription = user.SiteNavigation?.Description ?? string.Empty,
                UserTypeSubId = user.UserType?.SubId ?? 0,
                UserTypeDescription = user.UserType?.Description ?? string.Empty,
                Actions = actions
            };
        }

        public async Task<List<UserActionDto>> GetAllowedActionsForUserAsync(int userId)
        {
            // Get the user's UserTypeId
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Userid == userId);
            if (user == null)
                return new List<UserActionDto>();

            var userTypeId = user.UserTypeId;

            // Get allowed ActionIds from UsersPriv
            var actionIds = await _context.UsersPrivs
                .Where(up => up.UserTypeId == userTypeId)
                .Select(up => up.ActionId)
                .ToListAsync();

            // Get action details
            return await _context.Actions
                .Where(a => actionIds.Contains(a.ActionId) && !a.Disabled)
                .Select(a => new UserActionDto
                {
                    ActionId = a.ActionId,
                    ActionName = a.ActionName,
                    Module = a.Module
                })
                .ToListAsync();
        }
    }

    public class LoginResultDto
    {
        public string FullName { get; set; }
        public short SiteSubId { get; set; }
        public string SiteDescription { get; set; }
        public short UserTypeSubId { get; set; }
        public string UserTypeDescription { get; set; }
    }
}
