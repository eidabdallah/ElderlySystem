using EderlySystem.DAL.Enums;
using ElderlySystem.BLL.Helpers;
using ElderlySystem.DAL.DTO.Request.User;
using ElderlySystem.DAL.DTO.Response.User;
using ElderlySystem.DAL.Enums;
using ElderlySystem.DAL.Model;
using ElderlySystem.DAL.Repositories.User;
using Microsoft.AspNetCore.Identity;

namespace ElderlySystem.BLL.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(IUserRepository userRepository, UserManager<ApplicationUser> userManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
        }
        public async Task<ServiceResult> GetAllUserWithFilterAsync(Status? status, Role? role = null)
        {
            var users = await _userRepository.GetAllUserWithFilterAsync(status, role);

            if (users.Count == 0)
                return ServiceResult.SuccessMessage("لا يوجد مستخدمين");

            var userList = new List<UserInfoResponse>();
            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                userList.Add(new UserInfoResponse
                {
                    Id = user.Id,
                    Email = user.Email!,
                    FullName = user.FullName,
                    PhoneNumber = user.PhoneNumber!,
                    Role = roles.FirstOrDefault()!,
                    Status = user.Status
                });
            }

            return ServiceResult.SuccessWithData(userList, "تم جلب جميع المستخدمين");
        }

        public async Task<ServiceResult> ChangeUserRoleAsync(string userId, ChangeRoleRequest request)
        {
            var roleName = request.Role.ToString();
            if (!Enum.IsDefined(typeof(Role), request.Role))
                return ServiceResult.Failure("الدور المرسل غير صالح.");
            var result = await _userRepository.ChangeUserRoleAsync(userId, roleName);
            if (!result)
                return ServiceResult.Failure("حدث خطأ أثناء تغيير دور المستخدم.");
            return ServiceResult.SuccessMessage("تم تغيير دور المستخدم بنجاح.");
        }
        public async Task<bool> ChangeStatusAsync(string userId, Status newStatus)
        {
            return await _userRepository.ChangeStatusAsync(userId, newStatus);
        }

        public async Task<ServiceResult> GetByIdAsync(string UserId)
        {
            var user = await _userRepository.GetByIdAsync(UserId);
            if (user is null)   
            {
                return ServiceResult.Failure("المستخدم غير موجود");
            }
            var roles = await _userManager.GetRolesAsync(user);
            var userInfo = new UserInfoResponse()
            {
                Id = user.Id,
                Email = user.Email!,
                FullName = user.FullName,
                PhoneNumber = user.PhoneNumber!,
                Status = user.Status,
                Role = roles.FirstOrDefault()!
            };
            return ServiceResult.SuccessWithData(userInfo, "تم جلب معلومات المستخدم بنجاح");
        }
        public async Task<ServiceResult> IsBlockedAsync(string userId)
        {
            var isBlocked = await _userRepository.IsBlockedAsync(userId);
            return ServiceResult.SuccessMessage(isBlocked ? "المستخدم محظور حالياً" : "المستخدم غير محظور");
        }

        public async Task<ServiceResult> BlockUserAsync(string userId, int days)
        {
            var result = await _userRepository.BlockUserAsync(userId, days);

            if (!result)
                return ServiceResult.Failure("حدث خطأ أثناء حظر المستخدم.");

            return ServiceResult.SuccessMessage($"تم حظر المستخدم لمدة {days} يوم/أيام.");
        }

        public async Task<ServiceResult> UnBlockUserAsync(string userId)
        {
            var result = await _userRepository.UnBlockUserAsync(userId);

            if (!result)
                return ServiceResult.Failure("حدث خطأ أثناء فك الحظر عن المستخدم.");

            return ServiceResult.SuccessMessage("تم فك الحظر عن المستخدم بنجاح.");
        }

    }
}
