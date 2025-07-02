using Mega_Troni_Auto.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Mega_Troni_Auto.Data
{

    public class MegaTronixDbContext : DbContext
    {
        public MegaTronixDbContext(DbContextOptions<MegaTronixDbContext> options)
            : base(options) { }

        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
