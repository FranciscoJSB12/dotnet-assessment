using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using dot_net_assessment.Interfaces;
using dot_net_assessment.Dtos.Product;
using dot_net_assessment.Mappers;

namespace dot_net_assessment.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productsModel = await _productRepository.GetAllAsync();

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
            
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOne([FromBody] CreateProductRequestDto createProductRequesDto)
        {
            var productModel = createProductRequesDto.ToProductFromCreateDto();

            var product = await _productRepository.CreateOneAsync(productModel);

            return CreatedAtAction(nameof(GetOneById), new { id = productModel.Id }, productModel);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateOne([FromBody] UpdateProductRequestDto updateProductRequestDto, 
            [FromRoute] Guid id)
        {
            var productModel = await _productRepository.UpdateOneAsync(updateProductRequestDto.ToProductFromUpdateDto(), 
                id);

            if (productModel == null)
            {
                return NotFound();
            }

            return Ok(productModel);
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

            return Ok(productModel);
        }
    }
}


