using dot_net_assessment.Helpers;
using dot_net_assessment.Models;
using Microsoft.AspNetCore.Mvc;

namespace dot_net_assessment.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync(QueryObject query);

        Task<Product?> GetByIdAsync(Guid id);

        Task<Product> CreateOneAsync(Product productModel);

        Task<List<Product>> CreateManyAsync(List<Product> newProducts);

        Task<Product?> UpdateOneAsync(Product productModel, Guid id);

        Task<Product?> DeleteOneAsync(Guid id);
    }
}
