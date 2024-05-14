using CarDealership.Application.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CarDealership.Web.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarService _carService;
        
        public CarsController(ICarService carService)               
        {
            _carService = carService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCars()
        {
            return View("Main", await _carService.GetAvailableCars());
        }

        [HttpGet]
        public async Task<IActionResult> GetCar(int id)
        {
            return View("CarDetails", await _carService.GetCarById(id));
        }
    }
}
