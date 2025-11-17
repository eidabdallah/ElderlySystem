
using EA_Ecommerce.DAL.utils.SeedData;
using ElderlySystem.DAL.Data;
using ElderlySystem.DAL.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using System.Threading.Tasks;

namespace EderlySystem
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]));

            builder.Services.AddScoped<ISeedData, SeedData>();


            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedEmail = true;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference();
            }
            var scope = app.Services.CreateScope();
            var objectOfSeddData = scope.ServiceProvider.GetRequiredService<ISeedData>();
            await objectOfSeddData.IdentityDataSeedingAsync();


            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
