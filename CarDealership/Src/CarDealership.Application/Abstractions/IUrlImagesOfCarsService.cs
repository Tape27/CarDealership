using CarDealership.Application.Models.Dto.UrlImagesDto;
using Microsoft.AspNetCore.Http;

namespace CarDealership.Application.Abstractions
{
    public interface IUrlImagesOfCarsService
    {
        Task SaveImagesOfCarByCarId(int carId, IFormFile[] images);
        Task<IEnumerable<UrlImagesDto?>> GetImagesByCarId(int carId);

    }
}
