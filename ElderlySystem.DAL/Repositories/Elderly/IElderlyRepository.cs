using ElderlySystem.DAL.Model;

namespace ElderlySystem.DAL.Repositories.Elderly
{
    public interface IElderlyRepository
    {
        Task<List<DAL.Model.Elderly>> GetEldersBySponsorIdAsync(string sponsorId);
        Task<bool> ElderlyExistsAsync(string nationalId);
        Task<bool> AddElderlyAsync(DAL.Model.Elderly elderly);
        Task<bool> AddElderlySponsorAsync(ElderlySponsor relation);
        Task<DAL.Model.Elderly?> GetElderlyByNationalIdAsync(string nationalId);
        Task<bool> ExistsElderlyLinkToSponsorAsync(int elderlyId, string sponsorId);
        Task<bool> GetElderlyByIdAsync(int elderlyId);
        Task<List<DAL.Model.Elderly>> GetAllElderlyRegisterRequestAsync();
        Task<DAL.Model.Elderly?> GetEderlyDetailsAsync(int id);
        Task<bool> ChangeStatusElderlyAsync(int id);
    }
}
