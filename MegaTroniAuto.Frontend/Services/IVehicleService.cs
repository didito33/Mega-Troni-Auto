using MegaTroniAuto.Frontend.ViewModels;

namespace MegaTroniAuto.Frontend.Services
{
    public interface IVehicleService
    {
        Task<List<VehicleDto>> GetAllAsync();
    }
}
