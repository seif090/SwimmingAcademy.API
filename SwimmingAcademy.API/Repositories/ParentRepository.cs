using Microsoft.EntityFrameworkCore;
using SwimmingAcademy.API.Interfaces;
using SwimmingAcademy.API.Models;

namespace SwimmingAcademy.API.Repositories
{
    public class ParentRepository : IParentRepository
    {
        private readonly SwimminAcadmyContext _context;

        public ParentRepository(SwimminAcadmyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Parent>> GetAllAsync() =>
            await _context.Parents.Include(p => p.SwimmerName).ToListAsync();

        public async Task<Parent?> GetByIdAsync(int id) =>
            await _context.Parents.Include(p => p.SwimmerName).FirstOrDefaultAsync(p => p.SwimmerId == id);

        public async Task AddAsync(Parent parent)
        {
            await _context.Parents.AddAsync(parent);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Parent parent)
        {
            _context.Parents.Update(parent);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var parent = await _context.Parents.FindAsync(id);
            if (parent != null)
            {
                _context.Parents.Remove(parent);
                await _context.SaveChangesAsync();
            }
        }
    }
}
