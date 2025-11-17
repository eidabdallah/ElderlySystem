using ElderlySystem.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElderlySystem.DAL.Repositories.Sponsor
{
    public interface ISponsorRepository
    {
        Task<List<Elderly>> GetEldersBySponsorIdAsync(string sponsorId);
        Task<bool> ElderlyExistsAsync(string nationalId);
        Task<bool> AddElderlyAsync(Elderly elderly);
        Task<bool> AddElderlySponsorAsync(ElderlySponsor relation);
        Task<List<Elderly>> GetAllElderlyAsync();
        Task<bool> ExistsElderlyLinkToSponsorAsync(int elderlyId, string sponsorId);
        Task<bool> GetElderlyByIdAsync(int elderlyId);
    }
}
