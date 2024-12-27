using ECommerce.Data;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly EcommerceDatabaseContext _context;
        public CustomerRepository(EcommerceDatabaseContext context)
        {
            _context = context;
        }
        public Task AddAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            return _context.SaveChangesAsync();
        }

        public Task<List<Customer>> GetAllAsync()
        {
            return _context.Customers.ToListAsync();
        }
    }
}
