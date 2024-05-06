using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CarDealership.Application.Models.Dto.AdminDto
{
    public class CreateAdminDto
    {
        [Required] public string FullName { get; set; }
        [Required] public string Login { get; set; }

        [Required] 
        [MinLength(Domain.Constants.AdminModelConstants.MIN_PASSWORD_LENGTH)] 
        public string Password { get; set; }
        [Required] public string Role { get; set; }
        public IFormFile? Image { get; set; }
    }
}
