using Dealership.Models.ViewModels;

namespace Dealership.Services.Interface
{
    public interface IClientApiService
    {
        Task CreateOrderAsync (ViewOrderModel newOrder);
    }
}
