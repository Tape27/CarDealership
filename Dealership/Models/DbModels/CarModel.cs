using System.ComponentModel.DataAnnotations;

namespace Dealership.Models.DbModels
{
    public class CarModel
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Year { get; set; }
        public int Power { get; set; }
        public decimal Price { get; set; }
        public bool Exists { get; set; }
        public string? ImageUrl { get; set; }

    }
}
