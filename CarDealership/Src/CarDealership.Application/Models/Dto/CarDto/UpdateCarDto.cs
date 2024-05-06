using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CarDealership.Application.Models.Dto.CarDto
{
    public class UpdateCarDto
    {
        [Required] public int Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string Description { get; set; }
        [Required] public int Year { get; set; }
        [Required] public int Power { get; set; }
        [Required] public decimal Price { get; set; }
        [Required] public bool Exists { get; set; }
        public IFormFile? Image { get; set; }
    }
}
