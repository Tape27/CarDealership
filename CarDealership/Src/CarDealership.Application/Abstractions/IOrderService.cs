using CarDealership.Application.Models.Dto.OrderDto;
using CarDealership.Application.Models.ViewModels.OrderVm;

namespace CarDealership.Application.Abstractions
{
    public interface IOrderService
    {
        Task CreateOrder(CreateOrderDto request);
        Task<OrderDetailsListVm> GetAllOrders();
        Task<OrderListVm> GetUncompletedOrders();
        Task<int> GetCountUncompletedOrders();
        Task SetCompletedOrder(int id);
    }
}
