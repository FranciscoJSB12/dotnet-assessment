using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using dot_net_assessment.Interfaces;

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
            var products = await _productRepository.GetAllAsync();

            return Ok(products);
        }
    }
}


