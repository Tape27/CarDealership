using System.ComponentModel.DataAnnotations;

namespace Dealership.Models.ViewModels
{
    public class ViewCarModel
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string? Name { get; set; }

        [Required]
        [StringLength(2000)]
        public string? Description { get; set; }

        [Required]
        [Range(1900, 2100)]
        public string? Year { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Power { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        public bool Exists { get; set; }

        public IFormFile? Image { get; set; }
    }
}
