using CarDealership.Application.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarDealership.Web.Api
{
    [Route("api/car/")]
    [ApiController]
    public class CarApi : ControllerBase
    {
        private readonly ICarService _carService;
        public CarApi(ICarService carService)
        {
            _carService = carService;
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("delete/{id:int}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            await _carService.DeleteCar(id);

            return Ok();
        }
    }
}
