using Dealership.DataContext;
using Dealership.Models.DbModels;
using Dealership.Services.Interface.Admin;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Dealership.Services
{
    public class AdminAuthorizationService : IAdminAuthenticationService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ApplicationContext _dbContext;
        public AdminAuthorizationService(ApplicationContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;

        }
        private async Task SetDateAuthenticationAsync(int id)
        {
            var user = await _dbContext.Admins.FindAsync(id);

            if (user is not null)
            {
                user.DateLastAuth = DateTime.UtcNow;
                await _dbContext.SaveChangesAsync();
            }
        }
        public bool IsAuthenticatedAsync()
        {
            return _httpContextAccessor.HttpContext?.User.Identity?.IsAuthenticated ?? false;
        }
        public async Task<bool> AuthenticationAsync(string login, string password)
        {
            AdminModel? admin = await _dbContext.Admins.AsNoTracking()
                .Where(u => u.Login == login && u.Password == password)
                .FirstOrDefaultAsync();

            if (admin is not null)
            {
                var claims = new List<Claim> {
                    new Claim( "FullName", admin.FullName! ),
                    new Claim( "ImageUrl", admin.ImageUrl! ),
                    new Claim( ClaimTypes.Role, admin.Role! ),
                    new Claim( ClaimTypes.Name, login ),
                    new Claim( ClaimTypes.NameIdentifier, admin.Id.ToString() )
                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");

                await _httpContextAccessor!.HttpContext!.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));

                await SetDateAuthenticationAsync(admin.Id);

                return true;
            }
            return false;
        }

        public async Task LogoutAsync()
        {
            await _httpContextAccessor!.HttpContext!.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
