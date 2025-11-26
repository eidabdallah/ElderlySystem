using ElderlySystem.BLL.Helpers;
using ElderlySystem.BLL.Services.File;
using ElderlySystem.DAL.DTO.Request.ElderlySponsor;
using ElderlySystem.DAL.DTO.Response.ElderlySponsor;
using ElderlySystem.DAL.Model;
using ElderlySystem.DAL.Repositories.Elderly;
using Mapster;

namespace ElderlySystem.BLL.Service.Elderly
{
    public class ElderlyService : IElderlyService
    {
        private readonly IElderlyRepository _repository;
        private readonly IFileService _file;

        public ElderlyService(IElderlyRepository repository, IFileService file)
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

            var elderly = request.Adapt<DAL.Model.Elderly>();
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
        public async Task<ServiceResult> GetElderlyByNationalIdAsync(string nationalId)
        {
            var elderly = await _repository.GetElderlyByNationalIdAsync(nationalId);

            if (elderly is null)
                return ServiceResult.SuccessMessage("هذه المسنّة غير مسجّلة أو لم يتم قبولها.");

            var response = new { elderly.Id, elderly.Name, elderly.NationalId, elderly.Age, elderly.City, elderly.Street };

            return ServiceResult.SuccessWithData(response, "تم العثور على المسنّة بنجاح.");
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
        
        // for admin : 
        public async Task<ServiceResult> GetAllElderlyRegisterRequestAsync()
        {
            var request = await _repository.GetAllElderlyRegisterRequestAsync();
            var elderlies = request.Adapt<List<ElderlyRegisterInfoResponse>>();
            return ServiceResult.SuccessWithData(elderlies, "جلب جميع طلبات تسجيل المسنين");
        }
        public async Task<ServiceResult> GetEderlyDetailsAsync(int id)
        {
            var elderly = await _repository.GetEderlyDetailsAsync(id);

            if (elderly is null)
                return ServiceResult.Failure("المسن غير موجود.");

            var response = new ElderlyDetailsResponse
            {
                Id = elderly.Id,
                Name = elderly.Name,
                NationalId = elderly.NationalId,
                Age = elderly.Age,
                Doctrine = elderly.Doctrine,
                City = elderly.City,
                Street = elderly.Street,
                HealthStatus = elderly.HealthStatus,
                BDate = elderly.BDate,
                ComprehensiveExamination = elderly.ComprehensiveExamination,
                HealthInsurance = elderly.HealthInsurance,
                NationalIdImage = elderly.NationalIdImage,
                Diseases = elderly.Diseases.ToList(),
                Sponsors = elderly.ElderlySponsors.Select(es => new ElderlySponsorInfoResponse
                {
                    SponsorName = es.Sponsor.FullName,      
                    SponsorPhone = es.Sponsor.PhoneNumber,  
                    KinShipName = es.KinShip,               
                    Degree = es.Degree                       
                }).ToList()
            };
            return ServiceResult.SuccessWithData(response, "تم جلب تفاصيل المسن بنجاح");
        }
        // to accept ederly in system
        public async Task<ServiceResult> ChangeStatusElderlyAsync(int id)
        {
            var ederly = await _repository.ChangeStatusElderlyAsync(id);
            if (!ederly)
                return ServiceResult.Failure("المسن غير موجود");

            return ServiceResult.SuccessMessage("تم تغيير الحالة بنجاح");
        }
    }
}
