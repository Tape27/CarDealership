using CarDealership.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace CarDealership.Domain.Abstractions
{
    public interface IUrlImagesOfCarsRepository
    {
        Task Create(UrlImagesOfCarsModel model);
        Task<List<string>> SaveImagesByCarId(int carId, IFormFile[] images);
        Task<IEnumerable<UrlImagesOfCarsModel?>> GetByCarId(int carId);
        Task DeleteAllImagesByUrls(IEnumerable<string> urls);
        Task DeleteAllRowsByCarId(int id);
    }
}
