using CarDealership.Application.Abstractions;
using System.Security.Claims;
using CarDealership.Application.Abstractions.Auth;
using CarDealership.Application.Models.Dto.AdminDto;

namespace CarDealership.Web.Middleware
{
    public class UpdateAdminCookieMiddleware
    {
        private readonly RequestDelegate _next;
        public UpdateAdminCookieMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IAdminService adminService, 
            ICookiesProvider cookiesProvider,
            IHttpContextAccessor httpContextAccessor)
        {
            if (httpContextAccessor.HttpContext.User.Identity.IsAuthenticated &&
                context.User.FindFirstValue("Subject") != null)
            {
                var actualAdmin = await adminService.GetAdminForClaim(int.Parse(context.User.FindFirstValue("Subject")!));

                var currentAdmin = new AdminClaimDto
                {
                    Id = int.Parse(context.User.FindFirstValue("Subject")!),
                    FullName = context.User.FindFirstValue("FullName"),
                    Login = context.User.FindFirstValue(ClaimTypes.Name),
                    Role = context.User.FindFirstValue(ClaimTypes.Role),
                    ImageUrl = context.User.FindFirstValue("ImageUrl")
                };

                if (!currentAdmin.Equals(actualAdmin))
                {
                    await cookiesProvider.Set(actualAdmin);
                }
            }

            await _next(context);
        }
    }
}
