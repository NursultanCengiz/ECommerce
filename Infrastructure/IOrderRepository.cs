using ECommerce.Data;

namespace ECommerce.Infrastructure
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllAsync();
        Task<Order> GetByIdAsync(int id);
        Task AddAsync(Order order);
        Task<decimal> TotalAmout();
        Task<List<Order>> GetByDateAsync(DateTime date);
    }
}
