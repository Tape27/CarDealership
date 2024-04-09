using Dealership.Models.DbModels;

namespace Dealership.Services.Interface
{
    public interface IAdminApiService
    {
        public Task<bool> CompletedOrderAsync(int orderId);
        public Task<int> CountNotificationAsync();
        public Task<bool> DeleteCarAsync(int id);
        public Task<bool> DeleteUserAsync(int id);
    }
}
