using Dealership.DataContext;
using Dealership.Models.DbModels;
using Dealership.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace Dealership.Services
{
    public class ClientService : IClientService
    {
        private readonly ApplicationContext _dbContext;
        public ClientService(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<CarModel>> GetAvailableCarsAsync()
        {
            return await _dbContext.Cars.AsNoTracking().Where(x => x.Exists)
                .Select(x => new CarModel
            {
                Id = x.Id,
                Name = x.Name,
                Year = x.Year,
                Power = x.Power,
                Price = x.Price,
                ImageUrl = x.ImageUrl,

            }).ToListAsync();
        }

        public async Task<CarModel> GetCarByIdAsync(int id)
        {
            
            var car = await _dbContext.Cars.AsNoTracking().Where(x => x.Id == id)
                .Select(x => new CarModel
            {
                Name = x.Name,
                Year = x.Year,
                Power = x.Power,
                Price = x.Price,
                ImageUrl = x.ImageUrl,
                Description = x.Description,

            }).FirstOrDefaultAsync();

            return car!;
        }
    }
}
