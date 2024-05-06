using AutoMapper;
using CarDealership.Application.Common.Mapping;
using CarDealership.Domain.Models;

namespace CarDealership.Application.Models.ViewModels.AdminVm
{
    public class AdminVm : IMapWith<AdminModel>
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string FullName { get; set; }
        public string? ImageUrl { get; set; }
        public string Role { get; set; }
        public DateTime? DateLastAuth { get; set; }
        public int CountClosedOrders { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AdminModel, AdminVm>();
        }
    }
}
