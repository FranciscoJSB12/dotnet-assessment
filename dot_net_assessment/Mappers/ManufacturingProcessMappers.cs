using dot_net_assessment.Dtos.ManufactoringProcess;
using dot_net_assessment.Models;

namespace dot_net_assessment.Mappers
{
    public static class ManufacturingProcessMappers
    {
        public static ManufacturingProcessDto ToManufacturingProcessDto (
            this ManufacturingProcess manufacturingProcessModel)
        {
            return new ManufacturingProcessDto
            {
                Id = manufacturingProcessModel.Id,
                Type = manufacturingProcessModel.Type,
            };
        }
    }
}
