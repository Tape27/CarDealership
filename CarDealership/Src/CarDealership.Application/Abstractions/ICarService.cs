using CarDealership.Application.Models.Dto.CarDto;
using CarDealership.Application.Models.ViewModels.CarVm;

namespace CarDealership.Application.Abstractions
{
    public interface ICarService
    {
        Task<CarAdminDto> GetCarForEditById(int carId);
        Task<CarAdminListVm> GetAllCars();
        Task<CarListVm> GetAvailableCars();
        Task<CarDetailsVm> GetCarById(int carId);
        Task CreateCar(CreateCarDto newCar);
        Task UpdateCar(UpdateCarDto car);
        Task DeleteCar(int id);
    }
}
