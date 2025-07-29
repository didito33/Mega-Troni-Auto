namespace MegaTroniAuto.Frontend.ViewModels
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public FuelType FuelType { get; set; }
        public Transmission Transmission { get; set; }
        public int Mileage { get; set; } // in kilometers
        public string Color { get; set; } = string.Empty;
        public bool IsAvailable { get; set; } = true;
        public string ImageUrl { get; set; } = string.Empty;
    }
}
