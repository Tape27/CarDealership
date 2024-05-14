using CarDealership.Application.Models.Dto.AdminDto;

namespace CarDealership.Application.Abstractions.Auth
{
    
    public interface ICookiesProvider
    {
        Task Set(AdminClaimDto model);
        int? GetIdByCookies();
    }
}
