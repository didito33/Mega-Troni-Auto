using MegaTroniAuto.API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace MegaTroniAuto.API.Data
{

    public class MegaTronixDbContext : IdentityDbContext<ApplicationUser>
    {
        public MegaTronixDbContext(DbContextOptions<MegaTronixDbContext> options)
            : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
