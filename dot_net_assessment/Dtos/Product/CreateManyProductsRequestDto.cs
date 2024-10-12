using System.ComponentModel.DataAnnotations;

namespace dot_net_assessment.Dtos.Product
{
    public class CreateManyProductsRequestDto
    {
        [Required]
        [MinLength(2, ErrorMessage = "Provide at least two products")]
        public List<CreateProductRequestDto> Products { get; set; }
    }
}
