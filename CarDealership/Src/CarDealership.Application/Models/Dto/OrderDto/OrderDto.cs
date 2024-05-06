using AutoMapper;
using CarDealership.Application.Common.Mapping;
using CarDealership.Domain.Models;

namespace CarDealership.Application.Models.Dto.OrderDto
{
    public class OrderDto : IMapWith<OrderModel>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string? Message { get; set; }
        public string? Referrer { get; set; }
        public DateTime DateCreated { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<OrderModel, OrderDto>();
        }
    }
}
