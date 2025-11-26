using ElderlySystem.BLL.Helpers;
using ElderlySystem.DAL.DTO.Request.Room;

namespace ElderlySystem.BLL.Service.Room
{
    public interface IRoomService
    {
        Task<ServiceResult> AddRoomAsync(RoomCreateRequest request);
        Task<ServiceResult> UpdateRoomAsync(UpdateRoomRequest request, int id);
        Task<ServiceResult> ToggleRoomStatusAsync(int roomId);
        Task<ServiceResult> ChangeImageRoomAsync(int id, ImageRoomRequest request);
        Task<ServiceResult> DeleteRoomAsync(int id);
        Task<ServiceResult> GetRoomByIdAsync(int id);
        Task<ServiceResult> GetAllRoomAsync();
    }
}
