using CarDealership.Application.Models.Dto.CarDto;

namespace CarDealership.Application.Models.ViewModels.CarVm
{
    public class CarListVm
    {
        public IEnumerable<CarDto> Cars { get; set; }
    }
}
