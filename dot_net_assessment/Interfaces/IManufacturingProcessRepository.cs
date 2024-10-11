using dot_net_assessment.Models;

namespace dot_net_assessment.Interfaces
{
    public interface IManufacturingProcessRepository
    {
        Task<ManufacturingProcess?> GetByIdAsync(Guid id);

        Task<List<ManufacturingProcess>> GetAllAsync();
    }
}
