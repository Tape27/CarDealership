using Amazon.S3.Model;
using CarDealership.Domain.Abstractions;
using CarDealership.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace CarDealership.Infrastructure.Repository
{
    public class CarRepository : ICarRepository
    {
        private readonly CarDealershipDbContext _context;
        private readonly YandexCloudS3Context _cloudS3Context;
        public CarRepository(CarDealershipDbContext context,
            YandexCloudS3Context cloudS3Context)
        {
            _context = context;
            _cloudS3Context = cloudS3Context;
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
        public async Task DeleteMainImage(string url)
        {

            string key = _cloudS3Context.CarKey + YandexCloudHelper.GetFilenameFromUrl(url);

            var request = new DeleteObjectRequest
            {
                BucketName = _cloudS3Context.Bucket,
                Key = key
            };

            var response = await _cloudS3Context.S3Client.DeleteObjectAsync(request);

            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK ||
                response.HttpStatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return; //in progress
            }
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
            string fileName = Guid.NewGuid() + Path.GetExtension(image.FileName);
            string key = _cloudS3Context.CarKey + fileName;

            var request = new PutObjectRequest
            {
                BucketName = _cloudS3Context.Bucket,
                Key = key,
                InputStream = image.OpenReadStream()
            };
            var response = await _cloudS3Context.S3Client.PutObjectAsync(request);

            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK ||
                response.HttpStatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return $"{_cloudS3Context.ServiceUrl}/{_cloudS3Context.Bucket}/{key}";
            }

            return string.Empty;
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
