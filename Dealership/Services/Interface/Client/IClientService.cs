using Dealership.Models.DbModels;

namespace Dealership.Services.Interface
{
    public interface IClientService
    {
        Task<List<CarModel>> GetAvailableCarsAsync();
        Task<CarModel> GetCarByIdAsync(int id);
    }
}
