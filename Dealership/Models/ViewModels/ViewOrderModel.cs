using System.ComponentModel.DataAnnotations;

namespace Dealership.Models.ViewModels
{
    public class ViewOrderModel
    {
        [Required]
        [StringLength(100)]
        public string? Name { get; set; }
        [Required]
        [StringLength(25)]
        public string? PhoneNumber { get; set; }
        [StringLength(1000)]
        public string? Message { get; set; }
    }
}
