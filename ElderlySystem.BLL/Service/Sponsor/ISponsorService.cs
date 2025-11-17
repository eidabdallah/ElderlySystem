using ElderlySystem.BLL.Helpers;
using ElderlySystem.DAL.DTO.Request.ElderlySponsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElderlySystem.BLL.Service.Sponsor
{
    public interface ISponsorService
    {
        Task<ServiceResult> GetEldersBySponsorIdAsync(string sponsorId);
        Task<ServiceResult> AddElderlyBySponsorAsync(string sponsorId, ElderlyRegisterRequest request);
        Task<ServiceResult> GetAllElderlyAsync();
        Task<ServiceResult> LinkSponsorToElderlyAsync(string sponsorId, LinkElderlySponsorRequest request);

    }
}
