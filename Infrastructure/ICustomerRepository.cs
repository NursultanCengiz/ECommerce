using ECommerce.Data;

namespace ECommerce.Infrastructure
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllAsync();
        Task AddAsync(Customer customer);
    }
}
