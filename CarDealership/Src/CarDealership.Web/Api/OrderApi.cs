using CarDealership.Application.Abstractions;
using CarDealership.Application.Models.Dto.OrderDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarDealership.Web.Api
{
    [Route("order/")]
    [ApiController]
    public class OrderApi :  ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderApi(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [Route("create/")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromForm] CreateOrderDto newOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _orderService.CreateOrder(newOrder);

            return Ok();
        }

        [Authorize]
        [HttpPost("completed/{orderId:int}")]
        public async Task<IActionResult> CompletedOrder(int orderId)
        {
            await _orderService.SetCompletedOrder(orderId);
            return Ok();
        }

        [Authorize]
        [HttpGet("count/uncompleted/")]
        public async Task<int> CountNotification()
        {
            return await _orderService.GetCountUncompletedOrders();
        }
    }
}
