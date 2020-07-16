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

        public Task<StoreResponse> SaveAsync(Store store)
        {
            throw new NotImplementedException();
        }

        public Task<StoreResponse> UpdateAsync(int id, Store store)
        {
            throw new NotImplementedException();
        }

        public Task<StoreResponse> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
