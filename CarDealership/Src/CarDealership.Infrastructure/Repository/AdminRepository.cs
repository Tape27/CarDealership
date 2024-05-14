using Amazon.S3.Model;
using CarDealership.Domain.Abstractions;
using CarDealership.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace CarDealership.Infrastructure.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly YandexCloudS3Context _cloudS3Context;
        private readonly CarDealershipDbContext _context;

        public AdminRepository(YandexCloudS3Context cloudS3Context,
            CarDealershipDbContext context)
        {
            _cloudS3Context = cloudS3Context;
            _context = context;
        }

        public async Task SetDateLastAuthById(int id)
        {
            var model = await _context.Admins.FirstOrDefaultAsync(x => x.Id == id);

            if (model != null)
            {
                model.DateLastAuth = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            }
        }

        public async Task IncrementCompletedOrdersById(int id)
        {
            var model = await _context.Admins.FirstOrDefaultAsync(x => x.Id == id);

            if (model != null)
            {
                model.CountClosedOrders += 1;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<string?> GetImageUrlById(int id)
        {
            return await _context.Admins.Where(x => x.Id == id)
                .Select(x => x.ImageUrl)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> IsFreeLogin(string login)
        {
            int count = await _context.Admins.Where(x => x.Login == login).CountAsync();
            return count == 0;
        }

        public async Task Delete(int id)
        {
            await _context.Admins.Where(x => x.Id == id)
                .ExecuteDeleteAsync();
        }

        public async Task Update(AdminModel model)
        {
            await _context.Admins.Where(x => x.Id == model.Id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(x => x.FullName, model.FullName)
                    .SetProperty(x => x.Login, model.Login)
                    .SetProperty(x => x.Password, model.Password)
                    .SetProperty(x => x.Role, model.Role)
                    .SetProperty(x => x.ImageUrl, model.ImageUrl));
        }

        public async Task<IEnumerable<AdminModel>> GetAll()
        {
            return await _context.Admins.AsNoTracking().ToListAsync();
        }

        public async Task Create(AdminModel admin)
        {
            await _context.AddAsync(admin);
            await _context.SaveChangesAsync();
        }

        public async Task<string> SaveImage(IFormFile image)
        {

            string fileName = Guid.NewGuid() + Path.GetExtension(image.FileName);
            string key = _cloudS3Context.AdminKey + fileName;

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

        public async Task<AdminModel?> GetByLogin(string login)
        {
            return await _context.Admins
                .Where(x => x.Login == login)
                .FirstOrDefaultAsync();
        }

        public async Task<AdminModel?> GetById(int id)
        {
            return await _context.Admins.AsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task DeleteImage(string url)
        {

            string key = _cloudS3Context.AdminKey + YandexCloudHelper.GetFilenameFromUrl(url);

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
    }
}
