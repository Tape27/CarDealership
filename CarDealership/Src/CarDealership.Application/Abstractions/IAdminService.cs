using CarDealership.Application.Models.Dto.AdminDto;
using CarDealership.Application.Models.ViewModels.AdminVm;

namespace CarDealership.Application.Abstractions
{
    public interface IAdminService
    {
        Task<AdminVm> GetAdminById(int id);
        Task<AdminListVm> GetAllAdmins();
        Task Update(UpdateAdminDto updAdmin);
        Task Register(CreateAdminDto newAdmin);
        Task<bool> Login(string login, string password);
        bool IsAuthorized();
        Task Logout();
        Task DeleteAdmin(int id);
        Task<AdminClaimDto> GetAdminForClaim(int id);
    }
}
