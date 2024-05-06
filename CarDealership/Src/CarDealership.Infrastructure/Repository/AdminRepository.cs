using CarDealership.Domain.Abstractions;
using CarDealership.Domain.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace CarDealership.Infrastructure.Repository
{
    public class AdminRepository : IAdminRepository
    {
        
        private readonly CarDealershipDbContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public AdminRepository(CarDealershipDbContext context,
            IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
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
            string directory = @"\ImagesOfAdminsProfiles\";
            string fileName = Guid.NewGuid() + Path.GetExtension(image.FileName);
            string filePath = Path.Combine(_hostingEnvironment.WebRootPath + directory + fileName);

            await using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }

            return directory + fileName;
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

        public void DeleteImage(string fileName)
        {
            File.Delete(_hostingEnvironment.WebRootPath + fileName);
        }
    }
}
