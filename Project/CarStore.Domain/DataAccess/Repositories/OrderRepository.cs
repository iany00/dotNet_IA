using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CarStore.Domain.DataAccess.Contexts;
using CarStore.Domain.Models;
using CarStore.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CarStore.Domain.DataAccess.Repositories
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        public OrderRepository(ApiDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Order>> ListAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task AddAsync(Order order)
        {
             await _context.Orders.AddAsync(order);
        }

        public async Task<Order> FindByIdAsync(int id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public void Update(Order order)
        {
            _context.Orders.Update(order);
        }

        public void Remove(Order order)
        {
            _context.Orders.Remove(order);
        }
    }
}
