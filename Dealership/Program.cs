using Dealership.DataContext;
using Dealership.Services;
using Dealership.Services.Admin;
using Dealership.Services.Interface;
using Dealership.Services.Interface.Admin;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Dealership
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => {
                    options.Cookie.HttpOnly = true;
                    options.Cookie.Name = "Session";
                    options.LoginPath = "/admin/login";
                    options.AccessDeniedPath = "/admin/accessdenied";
                    });
                builder.Services.AddHttpContextAccessor();

            builder.Services.AddTransient<IAdminAuthenticationService, AdminAuthorizationService>();
            builder.Services.AddTransient<IAdminApiService, AdminApiService>();
            builder.Services.AddTransient<IAdminService, AdminService>();
            builder.Services.AddTransient<IClientApiService, ClientApiService>();
            builder.Services.AddTransient<IClientService, ClientService>();
            builder.Services.AddDbContext<ApplicationContext>();

            builder.Services.AddControllersWithViews();
            builder.Services.AddControllers();

            var app = builder.Build();

            app.UseStatusCodePagesWithReExecute("/Error/{0}");

            app.UseStaticFiles();

            app.UseAntiforgery();

            app.UseRouting();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Cars}/{action=GetCars}/{id?}");

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "Admin",
                pattern: "{controller=Admin}/{action=Login}/{id?}");

            app.Run();
        }
    }
}
