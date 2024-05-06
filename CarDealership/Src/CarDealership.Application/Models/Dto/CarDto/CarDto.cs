using AutoMapper;
using CarDealership.Application.Common.Mapping;
using CarDealership.Domain.Models;

namespace CarDealership.Application.Models.Dto.CarDto
{
    public class CarDto : IMapWith<CarModel>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int Power { get; set; }
        public decimal Price { get; set; }
        public string MainUrlImage { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CarModel, CarDto>();
        }
    }
}
