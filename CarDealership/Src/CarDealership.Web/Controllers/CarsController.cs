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

        //public async Task<IActionResult> CreateCar([FromBody] CarRequest newCar)
        //{
        //    var (car, error) = Car.Create(
        //        0,
        //        newCar.Name,
        //        newCar.Description,
        //        newCar.Year,
        //        newCar.Power,
        //        newCar.Price,
        //        newCar.Exist);

        //    if (!string.IsNullOrEmpty(error))
        //    {
        //        return BadRequest(error);
        //    }

        //    int carId = await _carService.CreateCar(car);

        //    return View("");
        //}
    }
}
