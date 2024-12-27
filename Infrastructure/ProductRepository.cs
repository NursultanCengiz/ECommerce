using ECommerce.Data;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure
{
    public class ProductRepository : IProductRepository
    {
        private readonly EcommerceDatabaseContext _context;
        public ProductRepository(EcommerceDatabaseContext context)
        {
            _context = context;
        }
        public Task AddAsync(Product product)
        {
            _context.Products.Add(product);
            return _context.SaveChangesAsync();
        }

        public bool AnyProduct(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }

        public Task DeleteAsync(Product product)
        {
            _context.Products.Remove(product);
            return _context.SaveChangesAsync();

        }

        public Task<List<Product>> GetAllAsync()
        {
            return _context.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            return product;
        }

        public Task<List<Product>> GetByPriceAsync(decimal price)
        {
           return _context.Products.Where(i=>i.Price >= price).ToListAsync();
        }

        public async Task<int> GetStocksAsync()
        {
            int total = 0;
            var products = await _context.Products.ToListAsync();
            total = products.Sum(i => i.Stock);
            return total;
        }

        public Task<Product> GetTopProductAsync()
        {
            return _context.Products.OrderBy(i=>i.Orders.Count).FirstAsync();
        }

        public Task UpdateAsync(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            return _context.SaveChangesAsync();
        }
    }
}
