using CarDealership.Application.Models.Dto.OrderDto;

namespace CarDealership.Application.Models.ViewModels.OrderVm
{
    public class OrderDetailsListVm
    {
        public IEnumerable<OrderDetailsDto> Orders { get; set; }
    }
}
