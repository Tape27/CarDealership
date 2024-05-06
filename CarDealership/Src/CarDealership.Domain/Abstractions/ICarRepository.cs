using CarDealership.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace CarDealership.Domain.Abstractions
{
    public interface ICarRepository
    {
        Task Create(CarModel car);
        Task<IEnumerable<CarModel>> GetAll();
        Task<IEnumerable<CarModel?>> GetAvailable();
        Task<CarModel?> GetById(int carId);
        Task<string> SaveMainImage(IFormFile image);
        Task Update(CarModel model);
        void DeleteMainImage(string fileName);
        Task Delete(int id);
        Task<string?> GetMainImageUrlById(int id);
    }
}
