using Microsoft.AspNetCore.Mvc;
using Dealership.Models.ViewModels;
using Dealership.Services.Interface;

namespace Dealership.Api
{
    [Route("api/")]
    [ApiController]
    public class ClientApi : ControllerBase
    {
        private readonly IClientApiService _clientApiService;
        public ClientApi(IClientApiService clientApiService)
        {
            _clientApiService = clientApiService;
        }

        [Route("createorder/")]
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromForm] ViewOrderModel newOrder)
        {
            if (ModelState.IsValid)
            {
                await _clientApiService.CreateOrderAsync(newOrder);
                return Ok();
            }

            return BadRequest(ModelState);
        }
    }
}
