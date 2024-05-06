using Application.Common.Exceptions;
using AutoMapper;
using CarDealership.Application.Abstractions;
using CarDealership.Application.Models.Dto.CarDto;
using CarDealership.Application.Models.ViewModels.CarVm;
using CarDealership.Domain.Abstractions;
using CarDealership.Domain.Models;
using FluentValidation;

namespace CarDealership.Application.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly IUrlImagesOfCarsService _urlImagesOfCarsService;
        private readonly IMapper _mapper;
        private readonly IImageValidator _imageValidator;
        private readonly IValidator<CarModel> _carValidator;
        public CarService(IUrlImagesOfCarsService urlImagesOfCarsService,
            ICarRepository carRepository,
            IMapper mapper,
            IImageValidator imageValidator,
            IValidator<CarModel> carValidator)
        {
            _urlImagesOfCarsService = urlImagesOfCarsService;
            _carRepository = carRepository;
            _mapper = mapper;
            _imageValidator = imageValidator;
            _carValidator = carValidator;
        }

        public async Task<CarAdminDto> GetCarForEditById(int carId)
        {
            var car = await _carRepository.GetById(carId);

            if (car == null || car.Id != carId)
            {
                throw new NotFoundException(nameof(car), carId);
            }

            var carDto = _mapper.Map<CarAdminDto>(car);

            return carDto;
        }

        public async Task<CarAdminListVm> GetAllCars()
        {
            var cars = await _carRepository.GetAll();

            var dtoCars = cars.Select(car => _mapper.Map<CarAdminDto>(car));

            return new CarAdminListVm { Cars = dtoCars };
        }
        public async Task<CarListVm> GetAvailableCars()
        {
            var cars = await _carRepository.GetAvailable();

            var dtoCars = cars.Select(car => _mapper.Map<CarDto>(car));

            return new CarListVm { Cars = dtoCars };
        }
        public async Task<CarDetailsVm> GetCarById(int carId)
        {
            var car = await _carRepository.GetById(carId);

            if (car == null || car.Id != carId)
            {
                throw new NotFoundException(nameof(car), carId);
            }

            var carDto = _mapper.Map<CarDetailsDto>(car);

            var images = await _urlImagesOfCarsService.GetImagesByCarId(car.Id);

            return new CarDetailsVm { Car = carDto, UrlImages = images };

        }
        public async Task CreateCar(CreateCarDto newCar)
        {
            var carModel = new CarModel
            {
                Name = newCar.Name,
                Description = newCar.Description,
                Power = newCar.Power,
                Price = newCar.Price,
                Exists = newCar.Exists,
                Year = newCar.Year,
            };

            if (!await _imageValidator.IsValidJpegFile(newCar.Image))
            {
                throw new ValidationException("Incorrect image file");
            }

            var validationResult = await _carValidator.ValidateAsync(carModel);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            carModel.MainUrlImage = await _carRepository.SaveMainImage(newCar.Image);

            await _carRepository.Create(carModel);

            if (newCar.OtherImages != null)
            {
                await _urlImagesOfCarsService.SaveImagesOfCarByCarId(carModel.Id, newCar.OtherImages);
            }
        }

        public async Task UpdateCar(UpdateCarDto updCar)
        {
            var car = await _carRepository.GetById(updCar.Id);

            if (car == null || car.Id != updCar.Id)
            {
                throw new NotFoundException(nameof(car), updCar.Id);
            }

            car.Name = updCar.Name;
            car.Description = updCar.Description;
            car.Power = updCar.Power;
            car.Price = updCar.Price;
            car.Exists = updCar.Exists;
            car.Year = updCar.Year;

            if (updCar.Image != null)
            {
                if (!await _imageValidator.IsValidJpegFile(updCar.Image))
                {
                    throw new ValidationException("Wrong file");
                }

                _carRepository.DeleteMainImage(car.MainUrlImage);

                car.MainUrlImage = await _carRepository.SaveMainImage(updCar.Image);
            }

            var validationResult = await _carValidator.ValidateAsync(car);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            await _carRepository.Update(car);
        }

        public async Task DeleteCar(int id)
        {
            string? url = await _carRepository.GetMainImageUrlById(id);

            if (!string.IsNullOrWhiteSpace(url))
            {
                _carRepository.DeleteMainImage(url);
            }

            await _carRepository.Delete(id);
        }

    }
}
