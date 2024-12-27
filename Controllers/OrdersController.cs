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
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return await _orderRepository.GetAllAsync();
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // POST: api/Orders
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            await _orderRepository.AddAsync(order);

            return CreatedAtAction("GetOrder", new { id = order.Id }, order);
        }
        
        // GET: api/Orders
        [HttpGet("/total")]
        public async Task<ActionResult<decimal>> GetTotalAmount()
        {
            return await _orderRepository.TotalAmout();
        }
        
        [HttpGet("{date}")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrderByDate(DateTime date)
        {
            return await _orderRepository.GetByDateAsync(date);
        }
    }
}
