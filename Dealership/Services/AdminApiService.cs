using Dealership.DataContext;
using Dealership.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Dealership.Services
{
    public class AdminApiService : IAdminApiService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ApplicationContext _dbContext;
        public AdminApiService(ApplicationContext dbContext, 
            IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task DeleteUserAsync(int id)
        {
            await _dbContext.Admins.Where(x => x.Id == id).ExecuteDeleteAsync();
        }
        public async Task DeleteCarAsync(int id)
        {
            await _dbContext.Cars.Where(x => x.Id == id).ExecuteDeleteAsync();
        }
        private async Task UserAddCountOrdersAsync()
        {
            int id = int.Parse(_httpContextAccessor.HttpContext?.User
                .FindFirstValue(ClaimTypes.NameIdentifier)!);

            var user = await _dbContext.Admins.FindAsync(id);

            if(user is not null) 
            {
                user.CountClosedOrders += 1;
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task CompletedOrderAsync(int orderId)
        {
            var orderInDb = await _dbContext.Orders.FindAsync(orderId);

            if (orderInDb is not null)
            {
                orderInDb.Checked = true;
                await _dbContext.SaveChangesAsync();
                await UserAddCountOrdersAsync();
            }
        }
        public async Task<int> CountNotificationAsync()
        {
            return await _dbContext.Orders.Where(x => x.Checked == false).CountAsync();
        }
    }
}
