using CarDealership.Application.Models.Dto.OrderDto;

namespace CarDealership.Application.Models.ViewModels.OrderVm
{
    public class OrderListVm
    {
        public IEnumerable<OrderDto> Orders { get; set; }
    }
}
