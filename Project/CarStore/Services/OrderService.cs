using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CarStore.API.Helpers;
using CarStore.Domain.Models;
using CarStore.Domain.Repositories;
using CarStore.Domain.Services;
using CarStore.Domain.Services.Communication;

namespace CarStore.API.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IStoreRepository _storeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IOrderRepository orderRepository, IStoreRepository storeRepository, IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _storeRepository = storeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Order>> ListAsync(int storeId, CancellationToken token)
        {
            return await _orderRepository.ListAsync(storeId, token);
        }

        public async Task<Order> GetAsync(int storeId, int id)
        {
            return await _orderRepository.FindStoreOrderAsync(storeId, id);
        }

        public async Task<OrderResponse> SaveAsync(int storeId, Order order)
        {
            var store = await _storeRepository.FindByIdAsync(storeId);
            if (store == null)
            {
                return new OrderResponse("Store not found.");
            }

            try
            {
                await _orderRepository.AddAsync(order);
                await _unitOfWork.CompleteAsync();

                return new OrderResponse(order);
            }
            catch (Exception e)
            {
                return new OrderResponse($"An error occurred when saving the order: {e.Message}");
            }
        }

        public async Task<OrderResponse> UpdateAsync(int storeId, int id, Order order, string ETag)
        {
            var store = await _storeRepository.FindByIdAsync(storeId);
            if (store == null)
            {
                return new OrderResponse("Store not found.");
            }

            var existingOrder = await _orderRepository.FindByIdAsync(id);
            if (existingOrder == null)
            {
                return new OrderResponse("Order not Found!");
            }

            if (HashFactory.GetHash(existingOrder.LastModified.ToString()) != ETag)
            {
                return new OrderResponse("Invalid If-match!");
            }

            existingOrder.CarId = order.CarId;
            existingOrder.StoreId = order.StoreId;
            existingOrder.UserId = order.UserId;
            existingOrder.LastModified = DateTime.Now;

            try
            {
                _orderRepository.Update(existingOrder);
                await _unitOfWork.CompleteAsync();

                return new OrderResponse(order);
            }
            catch (Exception e)
            {
                return new OrderResponse($"An error occurred when saving the order: {e.Message}");
            }
        }

        public async Task<OrderResponse> DeleteAsync(int id)
        {
            var existingOrder = await _orderRepository.FindByIdAsync(id);

            if (existingOrder == null)
            {
                return new OrderResponse("Order not Found!");
            }

            try
            {
                _orderRepository.Remove(existingOrder);
                await _unitOfWork.CompleteAsync();

                return new OrderResponse(existingOrder);
            }
            catch (Exception e)
            {
                return new OrderResponse($"An error occurred when deleting the order: {e.Message}");
            }
        }
    }
}
