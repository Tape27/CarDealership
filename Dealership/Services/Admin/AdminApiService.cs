using Dealership.DataContext;
using Dealership.Models.DbModels;
using Dealership.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Dealership.Services.Admin
{
    public class AdminApiService : IAdminApiService
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ApplicationContext _dbContext;
        public AdminApiService(ApplicationContext dbContext,
            IHttpContextAccessor httpContextAccessor,
            IWebHostEnvironment hostingEnvironment)
        {
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
            _hostingEnvironment = hostingEnvironment;
        }
        public async Task<bool> DeleteUserAsync(int id)
        {
            AdminModel? model = await _dbContext.Admins.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (model == null)
            {
                return false;
            }

            string filePath = Path.Combine(_hostingEnvironment.WebRootPath, model.ImageUrl!.TrimStart('/'));

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            _dbContext.Admins.Remove(model);
            await _dbContext.SaveChangesAsync();

            return true;

        }
        public async Task<bool> DeleteCarAsync(int id)
        {
            CarModel? model = await _dbContext.Cars.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (model == null)
            {
                return false;
            }

            string filePath = Path.Combine(_hostingEnvironment.WebRootPath, model.ImageUrl!.TrimStart('/'));

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            _dbContext.Cars.Remove(model);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        private async Task<bool> UserAddCountOrdersAsync()
        {
            int id = int.Parse(_httpContextAccessor.HttpContext?.User
                .FindFirstValue(ClaimTypes.NameIdentifier)!);

            var user = await _dbContext.Admins.FindAsync(id);

            if (user == null)
            {
                return false;
            }

            user.CountClosedOrders += 1;
            await _dbContext.SaveChangesAsync();

            return true;

        }
        public async Task<bool> CompletedOrderAsync(int orderId)
        {
            var orderInDb = await _dbContext.Orders.FindAsync(orderId);

            if (orderInDb == null)
            {
                return false;
            }

            orderInDb.Checked = true;
            await _dbContext.SaveChangesAsync();
            if (!await UserAddCountOrdersAsync())
            {
                return false;
            }

            return true;

        }
        public async Task<int> CountNotificationAsync()
        {
            return await _dbContext.Orders.Where(x => x.Checked == false).CountAsync();
        }
    }
}
