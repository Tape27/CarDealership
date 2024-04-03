using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Dealership.Services.Interface;
using Dealership.Models.ViewModels;

namespace Dealership.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService) 
        { 
            _adminService = adminService; 
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (_adminService.IsAuthenticatedAsync())
                return RedirectToAction("Index", "Admin");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string login, string password)
        {
            if (await _adminService.AuthenticationAsync(login,password))
            {
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                ViewData["Error"] = "Неверный логин или пароль";
                return View();
            }
        }
        public async Task<IActionResult> Logout()
        {
            await _adminService.LogoutAsync();
            return View("Login");
        }

        [Authorize]
        public IActionResult Index() 
        {
            return View("Main");
        }
        [Authorize]
        public async Task<IActionResult> Orders() 
        {
            var model = await _adminService.GetAvailableOrderAsync();
            return View("Orders", model);
        }
        [Authorize]
        public IActionResult DataBase()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> ViewCars()
        {
            return View(await _adminService.GetAllCarsAsync());
        }

        [Authorize]
        [HttpGet]
        public IActionResult CreateCar()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCar(ViewCarModel newcar)
        {
            if (ModelState.IsValid)
            {
                await _adminService.CreateCarAsync(newcar);
                ViewData["Error"] = "Авто успешно добавлено в базу данных";
            }
            else
            {
                ViewData["Error"] = "Указанные вами данные не валидны";
            }
            return View();
        }
        
        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUser(ViewAdminModel newuser)
        {
            if (ModelState.IsValid)
            {
                await _adminService.CreateUserAsync(newuser);
                ViewData["Error"] = "Пользователь успешно добавлено в базу данных";
            }
            else
            {
                ViewData["Error"] = "Указанные вами данные не валидны";
            }
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> ViewUsers()
        {
            
            return View(await _adminService.GetAllUsersAsync());
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> AllOrders()
        {
            return View(await _adminService.GetAllOrdersAsync());
        }

        [Authorize(Roles = "admin")]
        [HttpGet("admin/editcar/{carId:int}")]
        public async Task<IActionResult> EditCar(int carId)
        {
            var car = await _adminService.GetCarByIdAsync(carId);

            if (car is null)
                return NotFound();

            return View(car);
        }

        [Authorize(Roles = "admin")]
        [HttpPut("admin/editcar/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCar(int id, ViewCarModel updateCar)
        {
            if (ModelState.IsValid)
            {
                await _adminService.UpdateCarAsync(id, updateCar);
                ViewData["Error"] = "Информация об автомобиле успешно обновлена";
            }
            else
            {
                ViewData["Error"] = "Указанные вами данные не валидны";
            }
            return await EditCar(id);
        }

        [Authorize(Roles = "admin")]
        [HttpGet("admin/edituser/{id:int}")]
        public async Task<IActionResult> EditUser(int id)
        {
            return View(await _adminService.GetUserByIdAsync(id));
        }

        [Authorize(Roles = "admin")]
        [HttpPut("admin/edituser/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(int id, ViewAdminModel updateuser)
        {
            if (updateuser.Password is null)
            {
                ModelState.Remove("Password");
            }
            if (ModelState.IsValid)
            {
                await _adminService.UpdateUserAsync(id, updateuser);
                ViewData["Error"] = "Информация об пользователе успешно обновлена";
            }
            else
            {
                ViewData["Error"] = "Указанные вами данные не валидны";
            }

            return await EditUser(id);
        }

        [Authorize]
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
