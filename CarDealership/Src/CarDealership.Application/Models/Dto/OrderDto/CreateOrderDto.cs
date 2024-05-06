using System.ComponentModel.DataAnnotations;

namespace CarDealership.Application.Models.Dto.OrderDto
{
    public class CreateOrderDto
    {
        [Required] public string PhoneNumber { get; set; }
        [Required] public string Name { get; set; }
        public string? Message { get; set; }
        public string Referrer { get; set; }
    }
}
