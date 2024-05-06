using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using CarDealership.Application.Abstractions.Auth;
using CarDealership.Application.Models.Dto.AdminDto;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace CarDealership.Infrastructure.ClaimProvider
{
    public class CookiesProvider : ICookiesProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CookiesProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task Set(AdminClaimDto model)
        {
            var claims = new List<Claim> {
                    new Claim( "Subject", model.Id.ToString()),
                    new Claim( "FullName", model.FullName),
                    new Claim( ClaimTypes.Role, model.Role ),
                    new Claim( ClaimTypes.Name, model.Login ),
                };

            if (!string.IsNullOrEmpty(model.ImageUrl))
            {
                claims.Add(new Claim("ImageUrl", model.ImageUrl));
            }

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");

            await _httpContextAccessor!.HttpContext!.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));
        }
    }
}
