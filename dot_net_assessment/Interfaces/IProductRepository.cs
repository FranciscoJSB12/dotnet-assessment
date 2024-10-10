using dot_net_assessment.Models;

namespace dot_net_assessment.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
    }
}
