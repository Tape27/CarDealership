using CarDealership.Domain.Abstractions;
using CarDealership.Domain.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace CarDealership.Infrastructure.Repository
{
    public class UrlImagesOfCarsRepository : IUrlImagesOfCarsRepository
    {
        private readonly CarDealershipDbContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public UrlImagesOfCarsRepository(CarDealershipDbContext context,
            IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task Create(UrlImagesOfCarsModel model)
        {
            await _context.UrlImagesOfCars.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task<List<string>> SaveImagesByCarId(int carId, IFormFile[] images)
        {
            string directory = @"\ImagesOfCars\";
            var urls = new List<string>();

            foreach (var image in images)
            {
                string fileName = Guid.NewGuid() + Path.GetExtension(image.FileName);
                string filePath = Path.Combine(_hostingEnvironment.WebRootPath + directory + fileName);
                
                await using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }

                urls.Add(directory + fileName);
            }

            return urls;
        }

        public async Task<IEnumerable<UrlImagesOfCarsModel?>> GetByCarId(int carId)
        {
            return await _context.UrlImagesOfCars
                .Where(x => x.IdCar == carId)
                .ToListAsync();
        }

    }
}
