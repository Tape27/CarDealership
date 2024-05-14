using Amazon.S3.Model;
using CarDealership.Domain.Abstractions;
using CarDealership.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace CarDealership.Infrastructure.Repository
{
    public class UrlImagesOfCarsRepository : IUrlImagesOfCarsRepository
    {
        private readonly CarDealershipDbContext _context;
        private readonly YandexCloudS3Context _cloudS3Context;
        public UrlImagesOfCarsRepository(CarDealershipDbContext context,
            YandexCloudS3Context cloudS3Context)
        {
            _context = context;
            _cloudS3Context = cloudS3Context;
        }

        public async Task Create(UrlImagesOfCarsModel model)
        {
            await _context.UrlImagesOfCars.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAllImagesByUrls(IEnumerable<string> urls)
        {
            foreach (var url in urls)
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
                    //in progress
                }
            }
        }

        public async Task DeleteAllRowsByCarId(int id)
        {
            await _context.UrlImagesOfCars.Where(x => x.IdCar == id)
                .ExecuteDeleteAsync();
        }

        public async Task<List<string>> SaveImagesByCarId(int carId, IFormFile[] images)
        {
            var urls = new List<string>();

            foreach (var image in images)
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
                    urls.Add($"{_cloudS3Context.ServiceUrl}/{_cloudS3Context.Bucket}/{key}");
                }
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
