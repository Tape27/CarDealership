using CarDealership.Domain.Models;

namespace CarDealership.Domain.Abstractions
{
    public interface IOrderRepository
    {
        Task SetCompleted(int id);
        Task<int> Create(OrderModel order);
        Task<IEnumerable<OrderModel?>> GetUnchecked();
        Task<IEnumerable<OrderModel>> GetAll();
        Task<int> GetCountUnchecked();
    }
}
