using EderlySystem.DAL.Enums;
using ElderlySystem.DAL.Data;
using ElderlySystem.DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace ElderlySystem.DAL.Repositories.Elderly
{
    public class ElderlyRepository : IElderlyRepository
    {
        private readonly ApplicationDbContext _context;
        public ElderlyRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<DAL.Model.Elderly>> GetEldersBySponsorIdAsync(string sponsorId)
        {
            return await _context.ElderlySponsors
                .Where(es => es.SponsorId == sponsorId && es.status == Status.Active)
                .Select(es => es.Elderly)
                .ToListAsync();
        }

        public async Task<bool> ElderlyExistsAsync(string nationalId)
        {
            return await _context.Elderlies
                .AnyAsync(e => e.NationalId == nationalId);
        }
        public async Task<bool> AddElderlyAsync(DAL.Model.Elderly elderly)
        {
            await _context.Elderlies.AddAsync(elderly);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> AddElderlySponsorAsync(ElderlySponsor relation)
        {
            await _context.ElderlySponsors.AddAsync(relation);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<DAL.Model.Elderly?> GetElderlyByNationalIdAsync(string nationalId)
        {
            return await _context.Elderlies
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.NationalId == nationalId && e.status == Status.Active);
        }
        public async Task<bool> ExistsElderlyLinkToSponsorAsync(int elderlyId, string sponsorId)
        {
            return await _context.ElderlySponsors
                .AnyAsync(es => es.ElderlyId == elderlyId && es.SponsorId == sponsorId);
        }
        public async Task<bool> GetElderlyByIdAsync(int elderlyId)
        {
            return await _context.Elderlies
                                 .AnyAsync(e => e.Id == elderlyId);
        }
        public async Task<List<DAL.Model.Elderly>> GetAllElderlyRegisterRequestAsync()
        {
            return await _context.Elderlies.Where(e=> e.status == Status.Pending).AsNoTracking().ToListAsync();
        }
        public async Task<DAL.Model.Elderly?> GetEderlyDetailsAsync(int id)
        {
             return await _context.Elderlies.Include(e => e.ElderlySponsors)
               .ThenInclude(es => es.Sponsor).AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }
        public async Task<bool> ChangeStatusElderlyAsync(int id)
        {
            var elderly = await _context.Elderlies.FirstOrDefaultAsync(e => e.Id == id);

            if (elderly == null)
                return false;

            // Toggle
            elderly.status = elderly.status == Status.Pending
                ? Status.Active
                : Status.Pending;

            _context.Elderlies.Update(elderly);
            return await _context.SaveChangesAsync()>0;
        }
    }
}
