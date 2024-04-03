using Dealership.Models;
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
        public async Task CompletedOrder(int orderId)
        {
            await _adminApiService.CompletedOrderAsync(orderId);
        }
        [HttpGet("countnotification/")]
        public async Task<int> CountNotification()
        {
           return await _adminApiService.CountNotificationAsync();
        }
        [Authorize(Roles = "admin")]
        [HttpDelete("deletecar/{id:int}")]
        public async Task DeleteCar(int id)
        {
            await _adminApiService.DeleteCarAsync(id);
        }
        [Authorize(Roles = "admin")]
        [HttpDelete("deleteuser/{id:int}")]
        public async Task DeleteUser(int id) 
        {
            await _adminApiService.DeleteUserAsync(id);
        }

    }
}
