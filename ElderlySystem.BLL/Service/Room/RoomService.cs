using ElderlySystem.BLL.Helpers;
using ElderlySystem.BLL.Services.File;
using ElderlySystem.DAL.DTO.Request.Room;
using ElderlySystem.DAL.Enums;
using ElderlySystem.DAL.Model;
using ElderlySystem.DAL.Repositories.Room;

namespace ElderlySystem.BLL.Service.Room
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _repository;
        private readonly IFileService _file;

        public RoomService(IRoomRepository Repository , IFileService file)
        {
            _repository = Repository;
            _file = file;
        }
        public async Task<ServiceResult> AddRoomAsync(RoomCreateRequest request)
        {
            var checkRoomNumber = await _repository.CheckRoomNumberAsync(request.RoomNumber);
            if(checkRoomNumber)
                return ServiceResult.Failure("رقم الغرفة مستخدم");
            var room = new DAL.Model.Room
            {
                RoomNumber = request.RoomNumber,
                RoomType = request.RoomType,
                Capacity = request.Capacity,
                Price = request.Price,
                Description = request.Description,
            };
            if (request.Images != null && request.Images.Count > 0)
            {
                var uploadedImages = await _file.UploadMultipleAsync(request.Images, "rooms");
                room.RoomImages = uploadedImages.Select(x => new RoomImage
                      {
                          Url = x.Url,
                          PublicId = x.PublicId,
                      }).ToList();
            }
            await _repository.AddRoomAsync(room);
            return ServiceResult.SuccessMessage("تم إضافة الغرفة بنجاح.");
        }
        public async Task<ServiceResult> UpdateRoomAsync(UpdateRoomRequest request , int id)
        {
            var room = await _repository.GetRoomByIdAsync(id);
            if (room is null)
                return ServiceResult.Failure("الغرفة غير متوفره ");

            if (request.Price is not null)
                room.Price = request.Price.Value;
            if (request.RoomType is not null)
                room.RoomType = request.RoomType.Value;
            if (request.Capacity is not null)
            {
                if (request.Capacity < room.CurrentCapacity)
                    return ServiceResult.Failure("السعة الجديدة أقل من السعة الحالية، غير مسموح.");

                room.Capacity = request.Capacity.Value;
            }
            if (!string.IsNullOrWhiteSpace(request.Description))
                room.Description = request.Description;
            await _repository.SaveChangesAsync();
            return ServiceResult.SuccessMessage("تم تحديث بيانات الغرفة بنجاح.");
        }
        public async Task<ServiceResult> ToggleRoomStatusAsync(int roomId)
        {
            var room = await _repository.GetRoomByIdAsync(roomId);
            if (room is null)
                return ServiceResult.Failure("الغرفة غير متوفرة.");

            if(room.Status == RoomStatus.Active)
            {
                if(room.CurrentCapacity > 0) 
                    return ServiceResult.Failure("لا يمكن إيقاف الغرفة لأنها تحتوي على مقيمين حالياً.");
            }
            room.Status = room.Status == RoomStatus.Active
                ? RoomStatus.InActive
                : RoomStatus.Active;
            await _repository.SaveChangesAsync();
            return ServiceResult.SuccessMessage("تم تغيير حالة الغرفة بنجاح.");
        }
        public async Task<ServiceResult> ChangeImageRoomAsync(int id , ImageRoomRequest request)
        {
            var room = await _repository.GetRoomByIdWithImagesAsync(id);
            if (room is null)
                return ServiceResult.Failure("الغرفة غير متوفرة.");

            if (request.Images is null || !request.Images.Any())
                return ServiceResult.Failure("يجب إرسال صورة واحدة على الأقل.");
            foreach (var img in room.RoomImages.ToList())
            {
                await _file.DeleteAsync(img.PublicId);
            }

            var uploadedImages = await _file.UploadMultipleAsync(request.Images, "rooms");

            var updated = await _repository.UpdateRoomImagesAsync(room, uploadedImages);
            if (!updated)
                return ServiceResult.Failure("حدث خطأ أثناء تحديث صور الغرفة.");

            return ServiceResult.SuccessMessage("تم تحديث صور الغرفة بنجاح.");

        }


    }
}
