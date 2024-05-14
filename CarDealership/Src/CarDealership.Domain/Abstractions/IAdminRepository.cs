using CarDealership.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace CarDealership.Domain.Abstractions
{
    public interface IAdminRepository
    {
        Task<AdminModel?> GetById(int id);
        Task Create(AdminModel admin);
        Task Update(AdminModel model);
        Task<IEnumerable<AdminModel>> GetAll();
        Task<string> SaveImage(IFormFile image);
        Task DeleteImage(string url);
        Task<AdminModel?> GetByLogin(string login);
        Task Delete(int id);
        Task<bool> IsFreeLogin(string login);
        Task<string?> GetImageUrlById(int id);
        Task IncrementCompletedOrdersById(int id);
        Task SetDateLastAuthById(int id);
    }
}
