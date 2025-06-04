using Microsoft.EntityFrameworkCore;
using SwimmingAcademy.API.DTOs;
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

        public async Task<IEnumerable<Info2>> GetSwimmersByBranchAsync(short branchSubId)
        {
            // Fix for CS1061: Ensure the property 'SubId' exists in the Info2 class or replace it with the correct property.
            // Fix for CS0472: Remove the unnecessary null check for 'Site' since it is a value type.
            return await _context.Infos2
                .Include(s => s.SiteNavigation) // Assuming 'SiteNavigation' is the correct navigation property.
                .Where(s => s.SiteNavigation != null && s.SiteNavigation.SubId == branchSubId) // Replace 'SubId' with 'Site' or the correct property.
                .ToListAsync();
        }
        public async Task<List<ClubDto>> GetClubsAsync()
        {
            const short CLUB_MAIN_ID = 60; // Replace with your actual MainId for clubs
            return await _context.AppCodes
                .Where(ac => ac.MainId == CLUB_MAIN_ID)
                .Select(ac => new ClubDto
                {
                    SubId = ac.SubId,
                    Description = ac.Description
                })
                .ToListAsync();
        }
        public async Task<List<SwimmerListDto>> GetSwimmerListAsync()
        {
            return await _context.Infos2
                .Include(s => s.CurrentLevelNavigation)
                .Include(s => s.SiteNavigation)
                .Include(s => s.ClubNavigation)
                .Select(s => new SwimmerListDto
                {
                    Fullname = s.FulllName,
                    Birthdate = s.BirthDate,
                    CurrentLevel = s.CurrentLevelNavigation.Description,
                    Site = s.SiteNavigation.Description,
                    Club = s.ClubNavigation.Description
                })
                .ToListAsync();
        }

        public async Task<SwimmerTechnicalTabDto?> GetSwimmerTechnicalTabAsync(long swimmerId)
        {
            var detail = await _context.Details1
                .Include(d => d.Coach)
                .Include(d => d.SwimmerLevelNavigation)
                .FirstOrDefaultAsync(d => d.SwimmerId == swimmerId);

            if (detail == null)
                return null;

            return new SwimmerTechnicalTabDto
            {
                CoachFullName = detail.Coach?.FullName ?? string.Empty,
                SwimmerLevel = detail.SwimmerLevelNavigation?.Description ?? string.Empty,
                Attendance = detail.Attendence
            };
        }

        public async Task<SwimmerInfoTabDto?> GetSwimmerInfoTabAsync(int swimmerId)
        {
            var swimmer = await _context.Infos2
                .Include(s => s.CurrentLevelNavigation)
                .Include(s => s.StartLevelNavigation)
                .Include(s => s.ClubNavigation)
                .Include(s => s.Parent)
                .FirstOrDefaultAsync(s => s.SwimmerId == swimmerId);

            if (swimmer == null)
                return null;

            var parent = swimmer.Parent;

            return new SwimmerInfoTabDto
            {
                FullName = swimmer.FulllName,
                BirthDate = swimmer.BirthDate,
                CurrentLevel = swimmer.CurrentLevelNavigation?.Description ?? string.Empty,
                StartLevel = swimmer.StartLevelNavigation?.Description ?? string.Empty,
                CreatedAtDate = swimmer.CreatedAtDate,
                Club = swimmer.ClubNavigation?.Description ?? string.Empty,
                PrimaryJob = parent?.PrimaryJop ?? string.Empty,
                SecondaryJob = parent?.SecondaryJop ?? string.Empty,
                PrimaryPhone = parent?.PrimaryPhone ?? string.Empty,
                SecondaryPhone = parent?.SecondaryPhone ?? string.Empty
            };
        }

        public async Task<List<SwimmerLogTabDto>> GetSwimmerLogTabAsync(long swimmerId)
        {
            return await _context.Logs2
                .Where(l => l.SwimmerId == swimmerId)
                .Include(l => l.Action)
                .Include(l => l.CreatedByNavigation)
                .Include(l => l.CreatedAtsiteNavigation)
                .Select(l => new SwimmerLogTabDto
                {
                    ActionName = l.Action.ActionName,
                    FullName = l.CreatedByNavigation.Fullname,
                    CreatedAtDate = l.CreatedAtDate,
                    Site = l.CreatedAtsiteNavigation.Description
                })
                .ToListAsync();
        }

        public async Task AddSwimmerWithParentAsync(SwimmerCreateDto dto)
        {
            // Create swimmer entity (Info2)
            var swimmer = new Info2
            {
                FulllName = dto.FullName,
                BirthDate = dto.BirthDate,
                StartLevel = dto.StartLevel,
                Gender = dto.Gender,
                Club = dto.Club,
                CreatedAtDate = DateTime.UtcNow
            };

            await _context.Infos2.AddAsync(swimmer);
            await _context.SaveChangesAsync();

            // Create parent entity (Parent)
            var parent = new Parent
            {
                SwimmerId = swimmer.SwimmerId, // Link to swimmer
                PrimaryPhone = dto.PrimaryPhone,
                SecondaryPhone = dto.SecondaryPhone,
                PrimaryJop = dto.PrimaryJob,
                SecondaryJop = dto.SecondaryJob,
                Email = dto.Email,
                Address = dto.Address
            };

            await _context.Parents.AddAsync(parent);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateSwimmerInfoAsync(long swimmerId, SwimmerUpdateDto dto, int updatedBy, short updatedAtSite)
        {
            var swimmer = await _context.Infos2.FirstOrDefaultAsync(s => s.SwimmerId == swimmerId);
            if (swimmer == null)
                return false;

            swimmer.FulllName = dto.FullName;
            swimmer.BirthDate = dto.BirthDate;
            swimmer.StartLevel = dto.StartLevel;
            swimmer.Gender = dto.Gender;
            swimmer.Club = dto.Club;
            swimmer.UpdatedBy = updatedBy;
            swimmer.UpdatedAtSite = updatedAtSite;
            swimmer.UpdatedAtDate = DateTime.UtcNow;

            // Update parent info
            var parent = await _context.Parents.FirstOrDefaultAsync(p => p.SwimmerId == swimmerId);
            if (parent != null)
            {
                parent.PrimaryPhone = dto.PrimaryPhone;
                parent.SecondaryPhone = dto.SecondaryPhone;
                parent.PrimaryJop = dto.PrimaryJob;
                parent.SecondaryJop = dto.SecondaryJob;
                parent.Email = dto.Email;
                parent.Address = dto.Address;
            }

            await _context.SaveChangesAsync();
            return true;
        }
    }
}



