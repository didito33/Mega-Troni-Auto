using Mega_Troni_Auto.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Mega_Troni_Auto.Data
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
