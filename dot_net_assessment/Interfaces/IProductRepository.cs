using dot_net_assessment.Models;

namespace dot_net_assessment.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();

        Task<Product?> GetByIdAsync(Guid id);

        Task<Product> CreateOneAsync(Product productModel);

        Task<Product?> UpdateOneAsync(Product productModel, Guid id);

        Task<Product?> DeleteOneAsync(Guid id);
    }
}
