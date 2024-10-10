using Microsoft.EntityFrameworkCore;
using dot_net_assessment.Models;
using dot_net_assessment.Data;
using dot_net_assessment.Interfaces;

namespace dot_net_assessment.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly InventoryDbContext _dbContext;

        public ProductRepository(InventoryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _dbContext.Products.ToListAsync();   
        }
    }
}
