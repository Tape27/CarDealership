using Dealership.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Dealership.Controllers
{
    public class CarsController : Controller
    {
        private readonly IClientService _car;
        public CarsController(IClientService car)
        {
            _car = car;
        }

        [HttpGet]
        public async Task<IActionResult> GetCars()
        {
            return View("Main",await _car.GetAvailableCarsAsync());
        }
        [HttpGet]
        public async Task<ActionResult> GetCar(int id)
        {
            var car = await _car.GetCarByIdAsync(id);

            if(car is null)
                return NotFound();

            return View("CarDetails", car);
        }
    }
}
