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
                .Where(es => es.SponsorId == sponsorId).Include(es => es.Elderly)
                .Select(es => es.Elderly).ToListAsync();
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
        public async Task<List<DAL.Model.Elderly>> GetAllElderlyAsync()
        {
            return await _context.Elderlies
                .Select(e => new DAL.Model.Elderly
                {
                    Id = e.Id,
                    Name = e.Name
                })
                .ToListAsync();
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
    }
}
