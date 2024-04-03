using Dealership.DataContext;
using Dealership.Services.Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Dealership.Models.ViewModels;
using Dealership.Models.DbModels;

namespace Dealership.Services
{
    public class AdminService : IAdminService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ApplicationContext _dbContext;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public AdminService(ApplicationContext dbContext, IHttpContextAccessor httpContext, 
            IWebHostEnvironment hostingEnvironment)
        {
            _dbContext = dbContext;
            _httpContextAccessor = httpContext;
            _hostingEnvironment = hostingEnvironment;
        }
        public async Task<AdminModel> GetUserByIdAsync(int id)
        {
            return await _dbContext.Admins.FindAsync(id);
        }

        public async Task UpdateUserAsync(int idUser, ViewAdminModel updateUser)
        {
            var user = await _dbContext.Admins.FindAsync(idUser);

            if (user is not null)
            {
                user.FullName = updateUser.FullName;
                user.Login = updateUser.Login;
                user.Role = updateUser.Role;

                if(updateUser.Password is not null) 
                {
                    user.Password = updateUser.Password;
                }

                if (updateUser.Image != null && updateUser.Image.Length > 0)
                {
                    user.ImageUrl = "/ImagesOfAdminsProfiles/" + await SaveImageAsync(
                        "ImagesOfAdminsProfiles", updateUser.Image);
                }

                await _dbContext.SaveChangesAsync();
            }
        }
        private async Task<string> SaveImageAsync(string folder, IFormFile image)
        {
            var fileName = Guid.NewGuid() + Path.GetFileName(image.FileName);
            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, folder, fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }

            return fileName;
        }

        public async Task UpdateCarAsync(int idCar, ViewCarModel updateCar)
        {
            var car = await _dbContext.Cars.FindAsync(idCar);

            if (car is not null)
            {
                car.Name = updateCar.Name;
                car.Description = updateCar.Description;
                car.Year = updateCar.Year;
                car.Power = updateCar.Power;
                car.Price = updateCar.Price;
                car.Exists = updateCar.Exists;

                if (updateCar.Image != null && updateCar.Image.Length > 0)
                {
                    car.ImageUrl = "/ImagesOfCars/" + await SaveImageAsync
                        ("ImagesOfCars", updateCar.Image);
                }

                await _dbContext.SaveChangesAsync();
            }         
        }
        public async Task<CarModel> GetCarByIdAsync(int idCar)
        {
            return await _dbContext.Cars.Where(x => x.Id == idCar).FirstOrDefaultAsync();
        }
        public async Task<List<OrderModel>> GetAvailableOrderAsync()
        {
            return await _dbContext.Orders.AsNoTracking().Where(x => x.Checked == false)
                .ToListAsync();
        }
        private async Task SetDateAuthenticationAsync(int id)
        {
            var user = await _dbContext.Admins.FindAsync(id);

            if(user is not null)
            {            
                user.DateLastAuth = DateTime.UtcNow;
                await _dbContext.SaveChangesAsync();
            }
        }
        public bool IsAuthenticatedAsync()
        {
            return _httpContextAccessor.HttpContext?.User.Identity?.IsAuthenticated ?? false;
        }
        public async Task<bool> AuthenticationAsync(string login, string password)
        {
            AdminModel? admin = await _dbContext.Admins.AsNoTracking()
                .Where(u => u.Login == login && u.Password == password)
                .FirstOrDefaultAsync();

            if (admin is not null)
            {
                var claims = new List<Claim> {
                    new Claim( "FullName", admin.FullName! ),
                    new Claim( "ImageUrl", admin.ImageUrl! ),
                    new Claim( ClaimTypes.Role, admin.Role! ),
                    new Claim( ClaimTypes.Name, login ),
                    new Claim( ClaimTypes.NameIdentifier, admin.Id.ToString() )
                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");

                await _httpContextAccessor!.HttpContext!.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme, 
                    new ClaimsPrincipal(claimsIdentity));

                await SetDateAuthenticationAsync(admin.Id);

                return true;
            }
            return false;
        }

        public async Task LogoutAsync()
        {
            await _httpContextAccessor!.HttpContext!.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);
        }

        public async Task<List<CarModel>> GetAllCarsAsync()
        {
            return await _dbContext.Cars.AsNoTracking().ToListAsync();
        }

        public async Task CreateCarAsync(ViewCarModel newcar)
        {
            var car = new CarModel
            {
                Name = newcar.Name,
                Description = newcar.Description,
                Year = newcar.Year,
                Power = newcar.Power,
                Price = newcar.Price,
                Exists = newcar.Exists,
            };

            if (newcar.Image != null && newcar.Image.Length > 0)
            {
                car.ImageUrl = "/ImagesOfCars/" + 
                    await SaveImageAsync("ImagesOfCars", newcar.Image);
            }

            await _dbContext.Cars.AddAsync(car);
            await _dbContext.SaveChangesAsync();
        }

        public async Task CreateUserAsync(ViewAdminModel newuser)
        {
            var user = new AdminModel
            {
                FullName = newuser.FullName,
                Login = newuser.Login,
                Password = newuser.Password,
                Role = newuser.Role,
            };

            if (newuser.Image != null && newuser.Image.Length > 0)
            {
                user.ImageUrl = "/ImagesOfAdminsProfiles/" + 
                    await SaveImageAsync("ImagesOfAdminsProfiles", newuser.Image);
            }

            await _dbContext.Admins.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<AdminModel>> GetAllUsersAsync()
        {
            return await _dbContext.Admins.ToListAsync();
        }
        public async Task<List<OrderModel>> GetAllOrdersAsync()
        {
            return await _dbContext.Orders.ToListAsync();
        }
    }
}
