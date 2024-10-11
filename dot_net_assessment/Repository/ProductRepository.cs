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
            return await _dbContext.Products.Include("ManufacturingProcess").ToListAsync();   
        }

        public async Task<Product?> GetByIdAsync(Guid id)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
            return product;
        }

        public async Task<Product> CreateOneAsync(Product productModel)
        {
            await _dbContext.Products.AddAsync(productModel);
            await _dbContext.SaveChangesAsync();
            return productModel;
        }

        public async Task<Product?> UpdateOneAsync(Product productModel, Guid id)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return null;
            }

            product.Name = productModel.Name;
            product.Faulty = productModel.Faulty;
            product.Dispatched = productModel.Dispatched;
            product.ManufacturingProcessId = productModel.ManufacturingProcessId;

            await _dbContext.SaveChangesAsync();

            return product;
        }

        public async Task<Product?> DeleteOneAsync(Guid id)
        {
            var productModel = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (productModel == null)
            {
                return null;
            }

            _dbContext.Products.Remove(productModel);

            await _dbContext.SaveChangesAsync();

            return productModel;
        }
    }
}
