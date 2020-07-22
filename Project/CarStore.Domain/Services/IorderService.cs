using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CarStore.Domain.Models;
using CarStore.Domain.Services.Communication;

namespace CarStore.Domain.Services
{
    public interface IOrderService
    {
        Task<Order> GetAsync(int storeId, int id);
        Task<IEnumerable<Order>> ListAsync(int storeId, CancellationToken token);
        Task<OrderResponse> SaveAsync(int storeId, Order order);

        Task<OrderResponse> UpdateAsync(int storeId, int id, Order order, string ETag);
        Task<OrderResponse> DeleteAsync(int id);
    }
}
