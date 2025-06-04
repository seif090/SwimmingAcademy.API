using Microsoft.EntityFrameworkCore;
using SwimmingAcademy.API.Interfaces;
using SwimmingAcademy.API.Models;

namespace SwimmingAcademy.API.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly SwimminAcadmyContext _context;

        public AttendanceRepository(SwimminAcadmyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Detail>> GetAllAsync() =>
            await _context.Details.Include(a => a.Swimmer).ToListAsync();

        public async Task<Detail?> GetByIdAsync(int id) =>
            await _context.Details.Include(a => a.Swimmer).FirstOrDefaultAsync(a => a.SwimmerId == id);

        public async Task AddAsync(Detail attendance)
        {
            await _context.Details.AddAsync(attendance);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Detail attendance)
        {
            _context.Details.Update(attendance);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var attendance = await _context.Details.FindAsync(id);
            if (attendance != null)
            {
                _context.Details.Remove(attendance);
                await _context.SaveChangesAsync();
            }
        }
    }
}
