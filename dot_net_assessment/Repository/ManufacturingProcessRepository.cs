using dot_net_assessment.Data;
using dot_net_assessment.Interfaces;
using dot_net_assessment.Models;
using Microsoft.EntityFrameworkCore;

namespace dot_net_assessment.Repository
{
    public class ManufacturingProcessRepository : IManufacturingProcessRepository
    {
        private readonly InventoryDbContext _dbContext;

        public ManufacturingProcessRepository(InventoryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ManufacturingProcess>> GetAllAsync ()
        {
            return await _dbContext.ManufacturingProcesses.ToListAsync();
        }

        public async Task<ManufacturingProcess?> GetByIdAsync(Guid id)
        {   
            var manufacturingProcess = await _dbContext.ManufacturingProcesses.FirstOrDefaultAsync(m => m.Id == id);
            return manufacturingProcess;
        }
    }
}
