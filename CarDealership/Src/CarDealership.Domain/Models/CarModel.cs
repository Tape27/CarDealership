namespace CarDealership.Domain.Models
{
    public class CarModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public int Power { get; set; }
        public decimal Price { get; set; }
        public bool Exists { get; set; }
        public string MainUrlImage { get; set; }
    }
}
