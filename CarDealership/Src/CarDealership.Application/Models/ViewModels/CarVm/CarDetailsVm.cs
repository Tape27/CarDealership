using CarDealership.Application.Models.Dto.CarDto;
using CarDealership.Application.Models.Dto.UrlImagesDto;

namespace CarDealership.Application.Models.ViewModels.CarVm
{
    public class CarDetailsVm
    {
        public CarDetailsDto Car { get; set; }
        public IEnumerable<UrlImagesDto> UrlImages { get; set; }
    }
}
