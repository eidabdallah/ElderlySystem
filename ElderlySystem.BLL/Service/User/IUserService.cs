using EderlySystem.DAL.Enums;
using ElderlySystem.BLL.Helpers;
using ElderlySystem.DAL.DTO.Request.User;
using ElderlySystem.DAL.Enums;

namespace ElderlySystem.BLL.Services.User
{
    public interface IUserService
    {
        Task<ServiceResult> GetAllUserWithFilterAsync(Status? status, Role? role = null);
        Task<ServiceResult> ChangeUserRoleAsync(string userId, ChangeRoleRequest roleName);
        Task<bool> ChangeStatusToggleAsync(string userId);
        Task<ServiceResult> GetByIdAsync(string UserId);
        Task<ServiceResult> BlockUserAsync(string userId, int days);
        Task<ServiceResult> UnBlockUserAsync(string userId);
        Task<ServiceResult> IsBlockedAsync(string userId);
    }
}
