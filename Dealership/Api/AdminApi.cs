using Dealership.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dealership.Api
{
    [Authorize]
    [Route("admin/api/")]
    [ApiController]
    public class AdminApi : ControllerBase
    {
        IAdminApiService _adminApiService;

        public AdminApi(IAdminApiService adminApiService)
        {
            _adminApiService = adminApiService;
        }

        [HttpPost("completedorder/{orderId:int}")]
        public async Task<IActionResult> CompletedOrder(int orderId)
        {
            if(await _adminApiService.CompletedOrderAsync(orderId))
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpGet("countnotification/")]
        public async Task<int> CountNotification()
        {
           return await _adminApiService.CountNotificationAsync();
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("deletecar/{id:int}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            if(await _adminApiService.DeleteCarAsync(id))
            {
                return NoContent();
            }

            return NotFound();
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("deleteuser/{id:int}")]
        public async Task<IActionResult> DeleteUser(int id) 
        {
            if(await _adminApiService.DeleteUserAsync(id))
            {
                return NoContent();
            }

            return NotFound();
        }

    }
}
