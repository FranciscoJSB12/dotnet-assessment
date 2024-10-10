using Microsoft.EntityFrameworkCore;
using dot_net_assessment.Models;

namespace dot_net_assessment.Data
{
    public class InventoryDbContext: DbContext
    {
        public InventoryDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<ManufacturingProcess> ManufacturingProcesses  { get; set; }
    }
}
