namespace Mega_Troni_Auto.Models
{
    public class Vehicle
    {
        public Guid Id { get; set; }
        public string Brand { get; set; } = null!;
        public string Model { get; set; } = null!;
        public int Year { get; set; }
        public string FuelType { get; set; } = null!;
        public string Gearbox { get; set; } = null!;
        public int HorsePower { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; } = null!;
        public bool IsSold { get; set; } = false;
        public DateTime DateAdded { get; set; } = DateTime.UtcNow;
    }
}
