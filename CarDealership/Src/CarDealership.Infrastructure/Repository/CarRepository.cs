using CarDealership.Domain.Abstractions;
using CarDealership.Domain.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace CarDealership.Infrastructure.Repository
{
    public class CarRepository : ICarRepository
    {
        private readonly CarDealershipDbContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public CarRepository(CarDealershipDbContext context,
            IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<string?> GetMainImageUrlById(int id)
        {
            return await _context.Cars.Where(x => x.Id == id)
                .Select(x => x.MainUrlImage)
                .FirstOrDefaultAsync();
        }

        public async Task Delete(int id)
        {
            await _context.Cars.Where(x => x.Id == id)
                .ExecuteDeleteAsync();
        }
        public void DeleteMainImage(string fileName)
        {
            File.Delete(_hostingEnvironment.WebRootPath + fileName);
        }

        public async Task Update(CarModel model)
        {
            await _context.Cars.Where(x => x.Id == model.Id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(x => x.Name, model.Name)
                    .SetProperty(x => x.Description, model.Description)
                    .SetProperty(x => x.Exists, model.Exists)
                    .SetProperty(x => x.Power, model.Power)
                    .SetProperty(x => x.Price, model.Price)
                    .SetProperty(x => x.Year, model.Year)
                    .SetProperty(x => x.MainUrlImage, model.MainUrlImage));
        }

        public async Task<string> SaveMainImage(IFormFile image)
        {
            string directory = @"\ImagesOfCars\";
            string fileName = Guid.NewGuid() + Path.GetExtension(image.FileName);
            string filePath = Path.Combine(_hostingEnvironment.WebRootPath + directory + fileName);

            await using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }

            return directory + fileName;
        }

        public async Task Create(CarModel car)
        {
            await _context.AddAsync(car);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CarModel>> GetAll()
        {
            return await _context.Cars.AsNoTracking().ToListAsync();
        }


        public async Task<IEnumerable<CarModel?>> GetAvailable()
        {
           return await _context.Cars.Where(x => x.Exists == true)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<CarModel?> GetById(int carId)
        {
            return await _context.Cars.AsNoTracking().Where(x => x.Id == carId).FirstOrDefaultAsync();
        }
    }
}
