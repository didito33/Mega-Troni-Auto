using AutoMapper;
using MegaTroniAuto.API.Data;
using MegaTroniAuto.API.Models;
using MegaTroniAuto.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MegaTroniAuto.API.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly MegaTronixDbContext _context;
        private readonly IMapper _mapper;

        public VehicleService(MegaTronixDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Vehicle>> GetAllAsync()
        {
            return await _context.Vehicles.ToListAsync();
        }

        public async Task<Vehicle?> GetByIdAsync(Guid id)
        {
            return await _context.Vehicles.FindAsync(id);
        }

        public async Task<Vehicle> CreateAsync(VehicleCreateDto dto)
        {
            var vehicle = _mapper.Map<Vehicle>(dto);
            vehicle.Id = Guid.NewGuid();
            vehicle.DateAdded = DateTime.UtcNow;
            vehicle.IsSold = false;

            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();

            return vehicle;
        }

        public async Task<bool> UpdateAsync(Guid id, VehicleUpdateDto dto)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle == null) return false;

            _mapper.Map(dto, vehicle);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle == null) return false;

            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
