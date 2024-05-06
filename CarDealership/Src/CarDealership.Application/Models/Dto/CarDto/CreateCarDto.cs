using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace CarDealership.Application.Models.Dto.CarDto
{
    public class CreateCarDto
    {
        [Required] public string Name { get; set; }
        [Required] public string Description { get; set; }
        [Required] public int Year { get; set; }
        [Required] public int Power { get; set; }
        [Required] public decimal Price { get; set; }
        [Required] public bool Exists { get; set; }
        [Required] public IFormFile Image { get; set; }
        public IFormFile[]? OtherImages { get; set; }
    }
}
