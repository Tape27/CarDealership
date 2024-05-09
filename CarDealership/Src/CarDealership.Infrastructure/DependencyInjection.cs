using CarDealership.Application.Abstractions.Auth;
using CarDealership.Domain.Abstractions;
using CarDealership.Infrastructure.ClaimProvider;
using CarDealership.Infrastructure.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace CarDealership.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            string connectionString = configuration["CarDealershipDbContext"]!;

            services.AddDbContext<CarDealershipDbContext>(options =>
            {
                options.UseNpgsql(connectionString, 
                    b => b.MigrationsAssembly("CarDealership.Infrastructure"));
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.Cookie.Name = "session_id";
                    options.LoginPath = "/admin/login";
                    options.AccessDeniedPath = "/admin/accessdenied";
                    options.Cookie.HttpOnly = true;
                    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                    options.Cookie.SameSite = SameSiteMode.Strict;
                });

            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<ICookiesProvider, CookiesProvider>();
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IUrlImagesOfCarsRepository, UrlImagesOfCarsRepository>();

            return services;
        }
    }
}
