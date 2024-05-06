using CarDealership.Application.Models.Dto.CarDto;

namespace CarDealership.Application.Models.ViewModels.CarVm
{
    public class CarAdminListVm
    {
        public IEnumerable<CarAdminDto> Cars { get; set; }
    }
}
