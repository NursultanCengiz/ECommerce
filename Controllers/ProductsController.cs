using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ECommerce.Data;
using ECommerce.Infrastructure;

namespace ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _productRepository.GetAllAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            if (ProductExists(product.Id))
            {
                return NotFound();
            }
            await _productRepository.UpdateAsync(product);

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }
            if (string.IsNullOrEmpty(product.Name) || product.Price < 0)
            {
                return BadRequest();
            }
            await _productRepository.AddAsync(product);
            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            await _productRepository.DeleteAsync(product);
            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _productRepository.AnyProduct(id);
        }

        // GET: api/Products/500
        [HttpGet("{price}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByPrice(decimal price)
        {
            return await _productRepository.GetByPriceAsync(price);
        }

        [HttpGet("/stocks")]
        public async Task<ActionResult<int>> GetStocks()
        {
            return await _productRepository.GetStocksAsync();
        }

        [HttpGet("/topproduct")]
        public async Task<ActionResult<Product>> GetTopProduct()
        {
            return await _productRepository.GetTopProductAsync();
        }

    }
}
