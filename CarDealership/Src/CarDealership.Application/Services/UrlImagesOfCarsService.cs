using System.ComponentModel.DataAnnotations;
using AutoMapper;
using CarDealership.Application.Abstractions;
using CarDealership.Application.Models.Dto.UrlImagesDto;
using CarDealership.Domain.Abstractions;
using CarDealership.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace CarDealership.Application.Services
{
    public class UrlImagesOfCarsService : IUrlImagesOfCarsService
    {
        private readonly IUrlImagesOfCarsRepository _imagesOfCarsRepository;
        private readonly IMapper _mapper;
        private readonly IImageValidator _imageValidator;
        public UrlImagesOfCarsService(IUrlImagesOfCarsRepository imagesOfCarsRepository, 
            IMapper mapper,
            IImageValidator imageValidator)
        {
            _imagesOfCarsRepository = imagesOfCarsRepository;
            _mapper = mapper;
            _imageValidator = imageValidator;
        }

        public async Task DeleteImagesAndRowsByCarId(int id)
        {
            await _imagesOfCarsRepository.DeleteAllRowsByCarId(id);

            var urls = await _imagesOfCarsRepository.GetByCarId(id);

            if (urls != null && urls.Any())
            {
                await _imagesOfCarsRepository.DeleteAllImagesByUrls(urls.Select(x => x.Url));
            }
        }
        public async Task SaveImagesOfCarByCarId(int carId, IFormFile[] images)
        {
            foreach (var image in images)
            {
                if (!await _imageValidator.IsValidJpegFile(image))
                {
                    throw new ValidationException("Incorrect image file " + image.FileName);
                }
            }

            var urls = await _imagesOfCarsRepository.SaveImagesByCarId(carId, images);

            foreach (var url in urls)
            {
                var imageModel = new UrlImagesOfCarsModel
                {
                    Url = url,
                    IdCar = carId
                };

                await _imagesOfCarsRepository.Create(imageModel);
            }
        }

        public async Task<IEnumerable<UrlImagesDto?>> GetImagesByCarId(int carId)
        {
            var images = await _imagesOfCarsRepository.GetByCarId(carId);

            if (images == null)
            {
                return null;
            }

            return images.Select(image => _mapper.Map<UrlImagesDto>(image));
        }
    }
}
