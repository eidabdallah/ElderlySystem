using EderlySystem.DAL.Enums;
using ElderlySystem.DAL.Enums;
using ElderlySystem.DAL.Model;

namespace ElderlySystem.DAL.Repositories.User
{
    public interface IUserRepository
    {
        Task<List<ApplicationUser>> GetAllUserWithFilterAsync(Status? status = null, Role? role = null);
        Task<bool> ChangeUserRoleAsync(string userId, string roleName);
        Task<bool> ChangeStatusAsync(string userId, Status newStatus);
        Task<ApplicationUser?> GetByIdAsync(string userId);
        Task<bool> BlockUserAsync(string userId, int days);
        Task<bool> UnBlockUserAsync(string userId);
        Task<bool> IsBlockedAsync(string userId);


    }
}
