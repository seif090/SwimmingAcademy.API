using Microsoft.EntityFrameworkCore;
using SwimmingAcademy.API.Interfaces;
using SwimmingAcademy.API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwimmingAcademy.API.Repositories
{
    public class UserTypeRepository : IUserTypeRepository
    {
        private readonly SwimminAcadmyContext _context;
        private const short UserTypeMainId = 70; // Set to your actual MainId for user types

        public UserTypeRepository(SwimminAcadmyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UsersPriv>> GetAllAsync() =>
            await _context.UsersPrivs.ToListAsync();

        public async Task<UsersPriv?> GetByIdAsync(int id) =>
            await _context.UsersPrivs.FindAsync(id);

        public async Task AddAsync(UsersPriv type)
        {
            await _context.UsersPrivs.AddAsync(type);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UsersPriv type)
        {
            _context.UsersPrivs.Update(type);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var type = await _context.UsersPrivs.FindAsync(id);
            if (type is not null)
            {
                _context.UsersPrivs.Remove(type);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<AppCode>> GetUserTypesAsync()
        {
            return await _context.AppCodes
                .Where(a => a.MainId == UserTypeMainId)
                .ToListAsync();
        }

        public async Task<AppCode?> GetUserTypeByIdAsync(short mainId, short subId)
        {
            return await _context.AppCodes
                .FirstOrDefaultAsync(a => a.MainId == mainId && a.SubId == subId);
        }

        public async Task AddUserTypeAsync(AppCode userType)
        {
            await _context.AppCodes.AddAsync(userType);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserTypeAsync(AppCode userType)
        {
            _context.AppCodes.Update(userType);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserTypeAsync(short mainId, short subId)
        {
            var userType = await GetUserTypeByIdAsync(mainId, subId);
            if (userType != null)
            {
                _context.AppCodes.Remove(userType);
                await _context.SaveChangesAsync();
            }
        }
    }
}
