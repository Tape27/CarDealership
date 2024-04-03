
namespace Dealership.Services.Interface
{
    public interface IAdminApiService
    {
        public Task CompletedOrderAsync(int orderId);
        public Task<int> CountNotificationAsync();
        public Task DeleteCarAsync(int id);
        public Task DeleteUserAsync(int id);
    }
}
