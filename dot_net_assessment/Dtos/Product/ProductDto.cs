using dot_net_assessment.Dtos.ManufactoringProcess;

namespace dot_net_assessment.Dtos.Product
{
    public class ProductDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool Faulty { get; set; }

        public bool Dispatched { get; set; }

        public ManufacturingProcessDto ManufacturingProcess { get; set; }
    }
}
