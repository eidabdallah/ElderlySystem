using ElderlySystem.BLL.Helpers;
using ElderlySystem.BLL.Services.File;
using ElderlySystem.DAL.DTO.Request.ElderlySponsor;
using ElderlySystem.DAL.DTO.Response.ElderlySponsor;
using ElderlySystem.DAL.Model;
using ElderlySystem.DAL.Repositories.Sponsor;
using Mapster;

namespace ElderlySystem.BLL.Service.Sponsor
{
    public class SponsorService : ISponsorService
    {
        private readonly ISponsorRepository _repository;
        private readonly IFileService _file;

        public SponsorService(ISponsorRepository repository, IFileService file)
        {
            _repository = repository;
            _file = file;
        }
        public async Task<ServiceResult> GetEldersBySponsorIdAsync(string sponsorId)
        {
            var elderlies = await _repository.GetEldersBySponsorIdAsync(sponsorId);
            if (elderlies.Count == 0)
            {
                return ServiceResult.SuccessMessage("لا يوجد مسنين تابعين للكفيل");
            }
            var response = elderlies.Adapt<List<ElderlyInfoResponse>>();
            return ServiceResult.SuccessWithData(response, "تم جلب المسنين");
        }
        public async Task<ServiceResult> AddElderlyBySponsorAsync(string sponsorId, ElderlyRegisterRequest request)
        {
            if (await _repository.ElderlyExistsAsync(request.NationalId))
                return ServiceResult.Failure("رقم الهوية مستخدم سابقاً");

            var examImage = await _file.UploadAsync(request.ComprehensiveExamination, "elderly/exam");
            var nationalIdImage = await _file.UploadAsync(request.NationalIdImage, "elderly/national");
            var healthInsurance = await _file.UploadAsync(request.HealthInsurance, "elderly/insurance");

            var elderly = request.Adapt<Elderly>();
            elderly.ComprehensiveExamination = examImage.Url;
            elderly.NationalIdImage = nationalIdImage.Url;
            elderly.HealthInsurance = healthInsurance.Url;

            await _repository.AddElderlyAsync(elderly);
            var relation = new ElderlySponsor
            {
                Elderly = elderly,
                SponsorId = sponsorId,
                KinShip = request.KinShip,
                Degree = request.Degree
            };
            await _repository.AddElderlySponsorAsync(relation);
            return ServiceResult.SuccessMessage("تم اضافة المسن بنجاح");

        }
        public async Task<ServiceResult> GetAllElderlyAsync()
        {
            var elderlies = await _repository.GetAllElderlyAsync();

            if (elderlies.Count == 0)
                return ServiceResult.SuccessMessage("لا يوجد مسنين");

            var response = elderlies
                .Select(e => new { e.Id, e.Name })
                .ToList();

            return ServiceResult.SuccessWithData(response, "تم جلب جميع المسنين");
        }
        public async Task<ServiceResult> LinkSponsorToElderlyAsync(string sponsorId, LinkElderlySponsorRequest request)
        {
            var elderly = await _repository.GetElderlyByIdAsync(request.ElderlyId);
            if (!elderly)
                return ServiceResult.Failure("المسن غير موجود.");

            if (await _repository.ExistsElderlyLinkToSponsorAsync(request.ElderlyId, sponsorId))
                return ServiceResult.Failure("هذا الكفيل مرتبط مسبقاً بهذا المسن");
            var entity = new ElderlySponsor
            {
                ElderlyId = request.ElderlyId,
                SponsorId = sponsorId,
                KinShip = request.KinShip,
                Degree = request.Degree
            };
            await _repository.AddElderlySponsorAsync(entity);
            return ServiceResult.SuccessMessage("تم ربط الكفيل بالمسن بنجاح");
        }
    }
}
