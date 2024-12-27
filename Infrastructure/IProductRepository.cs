﻿using ECommerce.Data;

namespace ECommerce.Infrastructure
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(Product product);
        bool AnyProduct(int id);
        Task<List<Product>> GetByPriceAsync(decimal price);
        Task<int> GetStocksAsync();
        Task<Product> GetTopProductAsync();
    }
}