using AutoMapper;
using CarDealership.Application.Abstractions;
using CarDealership.Application.Models.Dto.OrderDto;
using CarDealership.Application.Models.ViewModels.OrderVm;
using CarDealership.Domain.Abstractions;
using CarDealership.Domain.Models;
using FluentValidation;

namespace CarDealership.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IValidator<OrderModel> _orderValidator;
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly IAdminService _adminService;
        public OrderService(IOrderRepository orderRepository, 
            IValidator<OrderModel> orderValidator,
            IMapper mapper,
            IAdminService adminService)
        {
            _orderRepository = orderRepository;
            _orderValidator = orderValidator;
            _mapper = mapper;
            _adminService = adminService;
        }

        public async Task<int> GetCountUncompletedOrders()
        {
            return await _orderRepository.GetCountUnchecked();
        }

        public async Task SetCompletedOrder(int id)
        {
            await _orderRepository.SetCompleted(id);

            await _adminService.IncrementClosedOrderByCookies();
        }
        public async Task CreateOrder(CreateOrderDto request)
        {
            var orderModel = new OrderModel
            {
                Name = request.Name,
                Message = request.Message,
                PhoneNumber = request.PhoneNumber,
                Referrer = request.Referrer,
                Checked = false,
                DateCreated = DateTime.UtcNow,
            };

            var validationResult = await _orderValidator.ValidateAsync(orderModel);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            await _orderRepository.Create(orderModel);
        }

        public async Task<OrderDetailsListVm> GetAllOrders()
        {
            var orders = await _orderRepository.GetAll();

            var ordersDto = orders.Select(order => _mapper.Map<OrderDetailsDto>(order));

            return new OrderDetailsListVm { Orders = ordersDto };
        }

        public async Task<OrderListVm> GetUncompletedOrders()
        {
            var orders = await _orderRepository.GetUnchecked();

            var ordersDto = orders.Select(order => _mapper.Map<OrderDto>(order));

            return new OrderListVm { Orders = ordersDto };
        }
    }
}
