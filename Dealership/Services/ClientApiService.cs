using Dealership.DataContext;
using Dealership.Models.DbModels;
using Dealership.Services.Interface;
using Dealership.Models.ViewModels;

namespace Dealership.Services
{
    public class ClientApiService : IClientApiService
    {
        private readonly ApplicationContext _dbContext;
        public ClientApiService(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateOrderAsync(ViewOrderModel newOrder)
        {
            var order = new OrderModel
            {
                Name = newOrder.Name,
                PhoneNumber = newOrder.PhoneNumber,
                Message = newOrder.Message,
                Checked = false,
                DateCreated = DateTime.UtcNow,
            };

            await _dbContext.AddAsync(order);
            await _dbContext.SaveChangesAsync();
        }

    }
}
