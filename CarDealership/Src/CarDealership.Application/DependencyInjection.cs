using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using CarDealership.Application.Abstractions;
using CarDealership.Application.Services;
using CarDealership.Application.Validators;
using CarDealership.Application.Common.Mapping;

namespace CarDealership.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IImageValidator, ImageValidator>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IUrlImagesOfCarsService, UrlImagesOfCarsService>();
            services.AddScoped<ICarService, CarService>();

            services.AddAutoMapper(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
            });

            services.AddValidatorsFromAssemblies([Assembly.GetExecutingAssembly()]);

            return services;
        }
    }
}
