using System.ComponentModel.DataAnnotations;

namespace Dealership.Models.ViewModels
{
    public class ViewAdminModel
    {
        [Required]
        [StringLength(100, MinimumLength = 10)]
        public string? FullName { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 7)]
        public string? Login { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 7)]
        public string? Password { get; set; }
        [Required]
        public string? Role { get; set; }
        public IFormFile? Image { get; set; }

    }
}
