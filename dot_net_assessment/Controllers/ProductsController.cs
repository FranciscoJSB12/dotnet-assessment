using Microsoft.AspNetCore.Mvc;
using dot_net_assessment.Interfaces;
using dot_net_assessment.Dtos.Product;
using dot_net_assessment.Mappers;
using dot_net_assessment.CustomActionFilters;
using dot_net_assessment.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace dot_net_assessment.Controllers
{
    [Route("api/products")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {

        private readonly IProductRepository _productRepository;
        private readonly IManufacturingProcessRepository _manufacturingProcessRepository;

        public ProductsController(IProductRepository productRepository, 
            IManufacturingProcessRepository manufacturingProcessRepository)
        {
            _productRepository = productRepository;
            _manufacturingProcessRepository = manufacturingProcessRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] QueryObject query
           )
        {
            var productsModel = await _productRepository.GetAllAsync(query);

            var products = productsModel.Select(p => p.ToProductDto());

            return Ok(products);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetOneById([FromRoute] Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }
            
            return Ok(product.ToProductDto());
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateOne([FromBody] CreateProductRequestDto createProductRequesDto)
        {
            var productModel = createProductRequesDto.ToProductFromCreateDto();
            
            var manufactoringProcess = await _manufacturingProcessRepository.GetByIdAsync(productModel.ManufacturingProcessId);

            if (manufactoringProcess == null)
            {
                return NotFound("Wrong Id for manufacturing process");
            }

            var product = await _productRepository.CreateOneAsync(productModel);


            productModel.ManufacturingProcess = manufactoringProcess;

            return CreatedAtAction(nameof(GetOneById), new { id = productModel.Id }, productModel.ToProductDto());
        }

        [HttpPost("insert-many")]
        [ValidateModel]
        public async Task<IActionResult> CreateMany([FromBody] CreateManyProductsRequestDto createManyProductsRequestDto)
        {
            var manufacturingProcesses = await _manufacturingProcessRepository.GetAllAsync();

            var manufacturingProcessIds = manufacturingProcesses.Select(m => m.Id).ToList();

            foreach(var product in createManyProductsRequestDto.Products)
            {
                if (!manufacturingProcessIds.Contains(product.ManufacturingProcessId))
                {
                    return BadRequest("Invalid manufacturing process Id in one item");
                }
            }
            
            var newProducts = createManyProductsRequestDto.Products.Select(p => p.ToProductFromCreateDto()).ToList();

            var savedProducts = await _productRepository.CreateManyAsync(newProducts);

            return Ok(savedProducts);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateOne([FromBody] UpdateProductRequestDto updateProductRequestDto, 
            [FromRoute] Guid id)
        {
            var manufactoringProcess = await _manufacturingProcessRepository.GetByIdAsync(updateProductRequestDto.ManufacturingProcessId);

            if (manufactoringProcess == null)
            {
                return NotFound("Invalid Id for manufacturing process");
            }

            var updatedProduct = await _productRepository.UpdateOneAsync(updateProductRequestDto.ToProductFromUpdateDto(), 
                id);

            if (updatedProduct == null)
            {
                return NotFound("Product not found");
            }

            return Ok(updatedProduct.ToProductDtoFromUpdateDto());
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteOne([FromRoute] Guid id)
        {
            var productModel = await _productRepository.DeleteOneAsync(id);

            if (productModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}


