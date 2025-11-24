using EA_Ecommerce.DAL.utils.SeedData;
using EA_Ecommerce.PL.utils;
using ElderlySystem.BLL.Service.Elderly;
using ElderlySystem.BLL.Service.Room;
using ElderlySystem.BLL.Services.Authentication;
using ElderlySystem.BLL.Services.File;
using ElderlySystem.BLL.Services.User;
using ElderlySystem.DAL.Repositories.Elderly;
using ElderlySystem.DAL.Repositories.Room;
using ElderlySystem.DAL.Repositories.User;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace ElderlySystem.PL
{
    internal static class AppConfiguration
    {
        internal static void AddConfig(this IServiceCollection services)
        {
            services.AddScoped<ISeedData, SeedData>();
            services.AddScoped<IAuthenticationService,AuthenticationService>();
            services.AddScoped<IEmailSender, EmailSetting>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IElderlyRepository, ElderlyRepository>();
            services.AddScoped<IElderlyService, ElderlyService>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IRoomRepository , RoomRepository>();
            services.AddScoped<IRoomService , RoomService>();
        }
    }
}
