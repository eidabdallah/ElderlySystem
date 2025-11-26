using ElderlySystem.BLL.Helpers;
using ElderlySystem.DAL.DTO.Request.Room;

namespace ElderlySystem.BLL.Service.Room
{
    public interface IRoomService
    {
        Task<ServiceResult> AddRoomAsync(RoomCreateRequest request);
        Task<ServiceResult> UpdateRoomAsync(UpdateRoomRequest request, int id);
    }
}
