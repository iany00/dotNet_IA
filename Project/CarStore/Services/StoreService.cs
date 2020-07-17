using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarStore.Domain.Models;
using CarStore.Domain.Repositories;
using CarStore.Domain.Services;
using CarStore.Domain.Services.Communication;

namespace CarStore.API.Services
{
    public class StoreService : IStoreService
    {
        private readonly IStoreRepository _storeRepository;
        private IUnitOfWork _unitOfWork;

        public StoreService(IStoreRepository storeRepository, IUnitOfWork unitOfWork)
        {
            _storeRepository = storeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Store>> ListAsync()
        {
           return await _storeRepository.ListAsync();
        }

        public async Task<StoreResponse> SaveAsync(Store store)
        {
            try
            {
                await _storeRepository.AddAsync(store);
                await _unitOfWork.CompleteAsync();

                return new StoreResponse(store);
            }
            catch (Exception e)
            {
                return new StoreResponse($"An error occurred when saving the store: {e.Message}");
            }
        }

        public async Task<StoreResponse> UpdateAsync(int id, Store store)
        {
            var existingStore = await _storeRepository.FindByIdAsync(id);

            if (existingStore == null)
            {
                return new StoreResponse("Store Not Found!");
            }

            existingStore.Name = store.Name;
            existingStore.Address = store.Address;

            try
            {
                _storeRepository.Update(existingStore);
                await _unitOfWork.CompleteAsync();

                return new StoreResponse(store);
            }
            catch (Exception e)
            {
                return new StoreResponse($"An error occurred when saving the store: {e.Message}");
            }
        }

        public async Task<StoreResponse> DeleteAsync(int id)
        {
            var existingStore = await _storeRepository.FindByIdAsync(id);

            if (existingStore == null)
            {
                return new StoreResponse("Store Not Found!");
            }

            try
            {
                _storeRepository.Remove(existingStore);
                await _unitOfWork.CompleteAsync();

                return new StoreResponse(existingStore);
            }
            catch (Exception e)
            {
                return new StoreResponse($"An error occurred when deleting the store: {e.Message}");
            }
        }
    }
}
