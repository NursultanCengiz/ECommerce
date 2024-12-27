using ECommerce.Data;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure
{
    public class OrderRepository : IOrderRepository
    {
        private readonly EcommerceDatabaseContext _context;
        public OrderRepository(EcommerceDatabaseContext context)
        {
            _context = context;
        }
        public Task AddAsync(Order order)
        {
            _context.Orders.Add(order);
            return _context.SaveChangesAsync();
        }

        public Task<List<Order>> GetAllAsync()
        {
            return _context.Orders.ToListAsync();
        }

        public Task<List<Order>> GetByDateAsync(DateTime date)
        {
            return _context.Orders.Where(i=>i.OrderDate >= date).ToListAsync();
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            return order;
        }

        public async Task<decimal> TotalAmout()
        {
            var orders = await _context.Orders.ToListAsync();
            decimal total = 0;
            foreach (var order in orders)
            {
                total += order.Product.Price;
            }
            return total;
        }
    }
}
