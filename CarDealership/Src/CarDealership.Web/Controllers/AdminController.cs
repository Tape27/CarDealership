using CarDealership.Application.Abstractions;
using CarDealership.Application.Models.Dto.AdminDto;
using CarDealership.Application.Models.Dto.CarDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarDealership.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly ICarService _carService;
        private readonly IOrderService _orderService;
        public AdminController(IAdminService adminService,
            ICarService carService,
            IOrderService orderService)
        {
            _adminService = adminService;
            _carService = carService;
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (_adminService.IsAuthorized())
                return RedirectToAction("Index");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string login, string password)
        {
            if (await _adminService.Login(login, password))
            {
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return View();
            }
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _adminService.Logout();
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
            return View("ViewOrders", await _orderService.GetUncompletedOrders());
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> AllOrders()
        {
            return View(await _orderService.GetAllOrders());
        }

        [Authorize]
        public IActionResult DataBase()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> ViewCars()
        {
            return View(await _carService.GetAllCars());
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
        public async Task<IActionResult> CreateCar([FromForm] CreateCarDto newCar)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            await _carService.CreateCar(newCar);

            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> EditCar(int id)
        {
            var car = await _carService.GetCarForEditById(id);

            if (car == null)
                return NotFound();

            return View(car);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCar([FromForm] UpdateCarDto edCar)
        {
            if (!ModelState.IsValid)
                return BadRequest();
                
            await _carService.UpdateCar(edCar);
            
            return RedirectToAction("ViewCars","Admin");
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult CreateAdmin()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAdmin([FromForm] CreateAdminDto newAdmin)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            

            await _adminService.Register(newAdmin);

            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> ViewAdmins()
        {

            return View(await _adminService.GetAllAdmins());
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> EditAdmin(int id)
        {
            return View(await _adminService.GetAdminById(id));
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAdmin([FromForm] UpdateAdminDto updAdmin)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            await _adminService.Update(updAdmin);
            
            return RedirectToAction("ViewAdmins", "Admin");
        }
        
        [Authorize]
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
