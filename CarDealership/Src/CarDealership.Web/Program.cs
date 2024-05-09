using CarDealership.Application;
using CarDealership.Application.Common.Mapping;
using CarDealership.Infrastructure;
using System.Reflection;
using CarDealership.Web.Middleware;

namespace CarDealership.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAutoMapper(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
            });

            Console.WriteLine("Connection: " + builder.Configuration["CarDealershipDbContext"]);

            builder.Services.AddHttpContextAccessor();
            builder.Services.AddApplication();
            builder.Services.AddInfrastructure(builder.Configuration);
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            //app.UseExceptionHandler();

            app.UseRouting();

            app.UseAuthentication();

            app.UseUpdateAdminCookies();

            app.UseAuthorization();
            app.UseAntiforgery();
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Cars}/{action=GetCars}/{id:int?}");

            app.MapControllerRoute(
                name: "Admin",
                pattern: "{controller=Admin}/{action=Login}/{id:int?}");
            app.Run();
        }
    }
}
