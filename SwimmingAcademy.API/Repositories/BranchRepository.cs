using Microsoft.EntityFrameworkCore;
using SwimmingAcademy.API.Interfaces;
using SwimmingAcademy.API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwimmingAcademy.API.Repositories
{
    public class BranchRepository : IBranchRepository
    {
        private readonly SwimminAcadmyContext _context;
        private const short BranchMainId = 60; // Set to your actual MainId for branches

        public BranchRepository(SwimminAcadmyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AppCode>> GetAllAsync() =>
            await _context.AppCodes.ToListAsync();

        public async Task<AppCode?> GetByIdAsync(int id) =>
            await _context.AppCodes.FirstOrDefaultAsync(a => a.MainId == id);

        public async Task AddAsync(AppCode branch)
        {
            await _context.AppCodes.AddAsync(branch);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(AppCode branch)
        {
            _context.AppCodes.Update(branch);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var branch = await _context.AppCodes.FindAsync(id);
            if (branch != null)
            {
                _context.AppCodes.Remove(branch);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<AppCode>> GetBranchesAsync()
        {
            return await _context.AppCodes
                .Where(a => a.MainId == BranchMainId)
                .ToListAsync();
        }

        public async Task<AppCode?> GetBranchByIdAsync(short mainId, short subId)
        {
            return await _context.AppCodes
                .FirstOrDefaultAsync(a => a.MainId == mainId && a.SubId == subId);
        }

        public async Task AddBranchAsync(AppCode branch)
        {
            await _context.AppCodes.AddAsync(branch);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBranchAsync(AppCode branch)
        {
            _context.AppCodes.Update(branch);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBranchAsync(short mainId, short subId)
        {
            var branch = await GetBranchByIdAsync(mainId, subId);
            if (branch != null)
            {
                _context.AppCodes.Remove(branch);
                await _context.SaveChangesAsync();
            }
        }
    }
}
