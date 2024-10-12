using Microsoft.EntityFrameworkCore;
using dot_net_assessment.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace dot_net_assessment.Data
{
    public class InventoryDbContext: IdentityDbContext<AppUser>
    {
        public InventoryDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<ManufacturingProcess> ManufacturingProcesses  { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var manufacturingProcesses = new List<ManufacturingProcess>
            {
                new ManufacturingProcess
                {
                    Id = Guid.Parse("a8fe47fd-0b62-49ae-a229-2790ff04c4d9"),
                    Type = "Elaborado a mano"
                },
                new ManufacturingProcess
                {
                    Id = Guid.Parse("d321ce3e-cd2f-4ce0-b8bd-16c28d06e13a"),
                    Type = "Elaborado a mano y a máquina"
                }
            };

            modelBuilder.Entity<ManufacturingProcess>().HasData(manufacturingProcesses);

            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                },
            };
            modelBuilder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
