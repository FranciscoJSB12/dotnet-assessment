namespace dot_net_assessment.Dtos.Product
{
    public class CreateProductRequestDto
    {
        public string Name { get; set; }

        public bool Faulty { get; set; }

        public bool Dispatched { get; set; }

        public Guid ManufacturingProcessId { get; set; }

    }
}
