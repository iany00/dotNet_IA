using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CarStore.Domain.DataAccess.Contexts;
using CarStore.Domain.Models;
using CarStore.Domain.Repositories;
using CarStore.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;

namespace CarStore.Domain.DataAccess.Repositories
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        private readonly IDistributedCache _cache;
        public OrderRepository(ApiDbContext context, ISimpleLogger logger, IDistributedCache cache) : base(context, logger)
        {
            _cache = cache;
        }

        // Distributed cache used
        public async Task<IEnumerable<Order>> ListAsync(int storeId, CancellationToken token)
        {
            var key = $"_orders_for_store_{storeId}";

            var orders = _cache.GetString(key);

            if (!string.IsNullOrEmpty(orders))
            {
                this._logger.LogInfo("DistributedCachedOrders-Get(storeId) cache hit");

                var orderList = Deserialize<List<Order>>(orders);

                return orderList;
            }
            else
            {
                this._logger.LogInfo("DistributedCachedOrders-Get(hotelId) db hit");

                var ordersEntities= await _context.Orders
                    .Include(c => c.Store)
                    .Where(c => c.Store.Id == storeId)
                    .ToListAsync(token);

                var options = new DistributedCacheEntryOptions();
                options.SetAbsoluteExpiration(TimeSpan.FromSeconds(3));

                _cache.SetString(key, Serialize(ordersEntities), options);

                return ordersEntities;
            }
        }

        public async Task AddAsync(Order order)
        {
             await _context.Orders.AddAsync(order);
        }

        public async Task<Order> FindByIdAsync(int id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public async Task<Order> FindStoreOrderAsync(int storeId, int id)
        {
            return await _context.Orders
                .Include(c => c.Store)
                .Where(c => c.Store.Id == storeId)
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();
        }

        public void Update(Order order)
        {
            _context.Entry(order).State = EntityState.Modified;
            _context.Orders.Update(order);
        }

        public void Remove(Order order)
        {
            _context.Orders.Remove(order);
        }
    }
}
