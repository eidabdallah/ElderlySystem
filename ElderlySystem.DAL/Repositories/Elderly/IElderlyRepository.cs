using ElderlySystem.DAL.Model;

namespace ElderlySystem.DAL.Repositories.Elderly
{
    public interface IElderlyRepository
    {
        Task<List<DAL.Model.Elderly>> GetEldersBySponsorIdAsync(string sponsorId);
        Task<bool> ElderlyExistsAsync(string nationalId);
        Task<bool> AddElderlyAsync(DAL.Model.Elderly elderly);
        Task<bool> AddElderlySponsorAsync(ElderlySponsor relation);
        Task<List<DAL.Model.Elderly>> GetAllElderlyAsync();
        Task<bool> ExistsElderlyLinkToSponsorAsync(int elderlyId, string sponsorId);
        Task<bool> GetElderlyByIdAsync(int elderlyId);
    }
}
