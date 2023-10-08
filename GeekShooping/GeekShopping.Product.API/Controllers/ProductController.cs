using GeekShopping.Product.API.DTO;
using GeekShopping.Product.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.Product.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
        {
            var product = await _productRepository.FindAllAsync();

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetById(long id)
        {
            var product = await _productRepository.FindByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDTO>> Create([FromBody] ProductDTO product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            var p = await _productRepository.CreateAsync(product);
            return Ok(p);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDTO>> Update(int id, [FromBody] ProductDTO product)
        {
            if (product == null)
            {
                return NotFound();
            }
            else if (product.Id != id)
            {
                return BadRequest();
            }

            var p = await _productRepository.UpdateAsync(product);
            return Ok(p);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var status = await _productRepository.DeleteAsync(id);

            if (!status)
            {
                return BadRequest();
            }

            return Ok(status);
        }
    }
}
