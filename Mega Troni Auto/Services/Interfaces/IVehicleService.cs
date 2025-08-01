﻿using MegaTroniAuto.API.Models;

namespace MegaTroniAuto.API.Services.Interfaces
{
    public interface IVehicleService
    {
        Task<IEnumerable<Vehicle>> GetAllAsync();
        Task<Vehicle?> GetByIdAsync(Guid id);
        Task<Vehicle> CreateAsync(VehicleCreateDto dto);
        Task<bool> UpdateAsync(Guid id, VehicleUpdateDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
