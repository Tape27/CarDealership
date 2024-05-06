using AutoMapper;
using CarDealership.Application.Models.ViewModels.AdminVm;
using CarDealership.Domain.Models;
using CarDealership.Application.Common.Mapping;

namespace CarDealership.Application.Models.Dto.AdminDto
{
    public class AdminClaimDto : IMapWith<AdminModel>
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Login { get; set; }
        public string Role { get; set; }
        public string? ImageUrl { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AdminModel, AdminClaimDto>();
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var other = (AdminClaimDto)obj;
            return Id == other.Id &&
                   FullName == other.FullName &&
                   Login == other.Login &&
                   Role == other.Role &&
                   ImageUrl == other.ImageUrl;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, FullName, Login, Role, ImageUrl);
        }
    }
}
