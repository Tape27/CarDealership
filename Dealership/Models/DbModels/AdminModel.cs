using System.ComponentModel.DataAnnotations;

namespace Dealership.Models.DbModels
{
    public class AdminModel
    {
        [Key]
        public int Id { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public string? FullName { get; set; }
        public string? ImageUrl { get; set; }
        public string? Role { get; set; }
        public DateTime? DateLastAuth { get; set; }
        public int CountClosedOrders { get; set; }
    }
}
