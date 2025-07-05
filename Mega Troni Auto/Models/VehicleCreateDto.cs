namespace MegaTroniAuto.API.Models
{
    public class VehicleCreateDto
    {
        public string Brand { get; set; } = null!;
        public string Model { get; set; } = null!;
        public int Year { get; set; }
        public string FuelType { get; set; } = null!;
        public string Gearbox { get; set; } = null!;
        public int HorsePower { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; } = null!;
    }
}
