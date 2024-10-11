using dot_net_assessment.Dtos.Product;
using dot_net_assessment.Models;

namespace dot_net_assessment.Mappers
{
    public static class ProductMappers
    {
        public static ProductDto ToProductDto (this Product productModel)
        {
            return new ProductDto
            {
                Id = productModel.Id,
                Name = productModel.Name,
                Dispatched = productModel.Dispatched,
                Faulty = productModel.Faulty,
                ManufacturingProcess = productModel.ManufacturingProcess.ToManufacturingProcessDto(),
            };
        }

        public static UpdatedProductDto ToProductDtoFromUpdateDto(this Product productModel)
        {
            return new UpdatedProductDto
            {
                Id = productModel.Id,
                Name = productModel.Name,
                Dispatched = productModel.Dispatched,
                Faulty = productModel.Faulty,
                ManufacturingProcessId = productModel.ManufacturingProcessId
            };
        }

        public static Product ToProductFromCreateDto(this CreateProductRequestDto productDto) 
        {
            return new Product
            {
                Name = productDto.Name,
                Faulty = productDto.Faulty,
                Dispatched = productDto.Dispatched,
                ManufacturingProcessId = productDto.ManufacturingProcessId,
            };
        }

        public static Product ToProductFromUpdateDto(this UpdateProductRequestDto producDto)
        {
            return new Product
            {
                Name = producDto.Name,
                Faulty = producDto.Faulty,
                Dispatched = producDto.Dispatched,
                ManufacturingProcessId = producDto.ManufacturingProcessId,
            };
        }
    }
}
