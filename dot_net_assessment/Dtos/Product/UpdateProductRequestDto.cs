using System.ComponentModel.DataAnnotations;

namespace dot_net_assessment.Dtos.Product
{
    public class UpdateProductRequestDto
    {
        [Required]
        [MinLength(2, ErrorMessage = "Provide At least two characters for a product name")]
        public string Name { get; set; }

        [Required]
        public bool Faulty { get; set; }

        [Required]
        public bool Dispatched { get; set; }

        [Required]
        public Guid ManufacturingProcessId { get; set; }
    }
}
