using Microsoft.EntityFrameworkCore;
using SwimmingAcademy.API.Interfaces;
using SwimmingAcademy.API.Models;

namespace SwimmingAcademy.API.Repositories
{
    public class LevelRepository : ILevelRepository
    {
        private readonly SwimminAcadmyContext _context;
        private const short PreTeamMainId = 11;   // Set to your actual PreTeam MainId
        private const short SwimmerMainId = 11;   // Set to your actual Swimmer MainId

        public LevelRepository(SwimminAcadmyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AppCode>> GetPreTeamLevelsAsync()
        {
            return await _context.AppCodes
                .Where(a => a.MainId == PreTeamMainId)
                .ToListAsync();
        }

        public async Task<IEnumerable<AppCode>> GetSwimmerLevelsAsync()
        {
            return await _context.AppCodes
                .Where(a => a.MainId == SwimmerMainId)
                .ToListAsync();
        }

        public async Task<AppCode?> GetLevelByIdAsync(short mainId, short subId)
        {
            return await _context.AppCodes
                .FirstOrDefaultAsync(a => a.MainId == mainId && a.SubId == subId);
        }

        public async Task AddLevelAsync(AppCode level)
        {
            await _context.AppCodes.AddAsync(level);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateLevelAsync(AppCode level)
        {
            _context.AppCodes.Update(level);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLevelAsync(short mainId, short subId)
        {
            var level = await GetLevelByIdAsync(mainId, subId);
            if (level != null)
            {
                _context.AppCodes.Remove(level);
                await _context.SaveChangesAsync();
            }
        }
    }
}
