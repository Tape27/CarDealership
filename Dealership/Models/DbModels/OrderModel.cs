namespace Dealership.Models.DbModels
{
    public class OrderModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Message { get; set; }
        public bool Checked { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
