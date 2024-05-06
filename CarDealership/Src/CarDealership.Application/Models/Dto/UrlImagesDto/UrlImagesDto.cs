using AutoMapper;
using CarDealership.Application.Common.Mapping;
using CarDealership.Domain.Models;

namespace CarDealership.Application.Models.Dto.UrlImagesDto
{
    public class UrlImagesDto : IMapWith<UrlImagesOfCarsModel>
    {
        public string Url { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UrlImagesOfCarsModel, UrlImagesDto>();
        }
    }
}
