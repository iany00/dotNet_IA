﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CarStore.Domain.Models;
using CarStore.Domain.Services.Communication;

namespace CarStore.Domain.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> ListAsync();
        Task<OrderResponse> SaveAsync(Order order);

        Task<OrderResponse> UpdateAsync(int id, Order order);
        Task<OrderResponse> DeleteAsync(int id);
    }
}