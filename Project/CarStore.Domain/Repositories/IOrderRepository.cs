using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CarStore.Domain.Models;

namespace CarStore.Domain.Repositories
{
    public interface IOrderRepository
    {

        Task<IEnumerable<Order>> ListAsync();
        Task AddAsync(Order order);
        Task<Order> FindByIdAsync(int id);

        void Update(Order order);

        void Remove(Order order);
    }
}
