using Microsoft.EntityFrameworkCore;
using SwimmingAcademy.API.Interfaces;
using SwimmingAcademy.API.Models;

namespace SwimmingAcademy.API.Repositories
{
    public class SwimmerRepository : ISwimmerRepository
    {
        private readonly SwimminAcadmyContext _context;

        public SwimmerRepository(SwimminAcadmyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Info2>> GetAllAsync() =>
            await _context.Infos2.Include(s => s.Site).ToListAsync();

        public async Task<Info2?> GetByIdAsync(int id) =>
            await _context.Infos2.Include(s => s.Site).FirstOrDefaultAsync(s => s.SwimmerId == id);

        public async Task AddAsync(Info2 swimmer)
        {
            await _context.Infos2.AddAsync(swimmer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Info2 swimmer)
        {
            _context.Infos2.Update(swimmer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var swimmer = await _context.Infos2.FindAsync(id);
            if (swimmer != null)
            {
                _context.Infos2.Remove(swimmer);
                await _context.SaveChangesAsync();
            }
        }
    }
}
