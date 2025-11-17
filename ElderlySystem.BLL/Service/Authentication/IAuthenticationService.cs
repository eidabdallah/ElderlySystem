using ElderlySystem.BLL.Helpers;
using ElderlySystem.DAL.DTO.Request.Auth;
using Microsoft.AspNetCore.Http;

namespace ElderlySystem.BLL.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<ServiceResult> LoginAsync(LoginRequest request);
        Task<ServiceResult> RegisterAsync(RegisterRequest request , HttpRequest HttpRequest);
        Task<bool> ConfirmEmail(string token, string userId);

        Task<ServiceResult> ForgotPassword(ForgotPasswordRequest forgotPasswordRequest);
        Task<ServiceResult> ResetPassword(ResetPasswordRequest resetPasswordRequest);

    }
}
