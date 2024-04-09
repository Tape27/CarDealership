using Dealership.Models.DbModels;
using Dealership.Models.ViewModels;

namespace Dealership.Services.Interface
{
    public interface IAdminService
    {
        Task<List<OrderModel>> GetAvailableOrderAsync();
        Task<List<CarModel>> GetAllCarsAsync();
        public Task CreateCarAsync(ViewCarModel newcar);
        public Task CreateUserAsync(ViewAdminModel newuser);
        public Task<List<AdminModel>> GetAllUsersAsync();
        public Task<List<OrderModel>> GetAllOrdersAsync();
        public Task<CarModel> GetCarByIdAsync(int idCar);
        public Task UpdateCarAsync(int idCar, ViewCarModel updatecar);
        public Task<AdminModel> GetUserByIdAsync(int idUser);
        public Task UpdateUserAsync(int idUser, ViewAdminModel updateUser);
    }
}
