using CarDealership.Application.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarDealership.Web.Api
{
    [Authorize]
    [Route("api/admin/")]
    [ApiController]
    public class AdminApi : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminApi(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("delete/{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _adminService.DeleteAdmin(id);

            return Ok();
        }
    }
}
