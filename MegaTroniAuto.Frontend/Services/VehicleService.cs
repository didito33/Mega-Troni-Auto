using MegaTroniAuto.Frontend.ViewModels;

namespace MegaTroniAuto.Frontend.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly HttpClient _http;

        public VehicleService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Vehicle>> GetAllAsync()
        {
            var result = await _http.GetFromJsonAsync<List<Vehicle>>("api/vehicles");
            return result ?? new List<Vehicle>();
        }
    }
}
