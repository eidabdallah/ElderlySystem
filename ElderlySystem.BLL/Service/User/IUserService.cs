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
        Task<bool> BlockUserAsync(string userId, int days);
        Task<bool> UnBlockUserAsync(string userId);
        Task<bool> IsBlockedAsync(string userId);
    }
}
