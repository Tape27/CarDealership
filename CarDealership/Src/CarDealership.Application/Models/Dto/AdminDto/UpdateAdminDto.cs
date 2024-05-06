using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CarDealership.Application.Models.Dto.AdminDto
{
    public class UpdateAdminDto
    {
        [Required] public int Id { get; set; }
        [Required] public string FullName { get; set; }
        [Required] public string Login { get; set; }
        public string? Password { get; set; }
        [Required] public string Role { get; set; }
        public IFormFile? Image { get; set; }
    }
}
