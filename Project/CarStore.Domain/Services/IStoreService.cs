using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CarStore.Domain.Models;
using CarStore.Domain.Services.Communication;

namespace CarStore.Domain.Services
{
    public interface IStoreService
    {
        Task<IEnumerable<Store>> ListAsync();
        Task<StoreResponse> SaveAsync(Store store);

        Task<StoreResponse> UpdateAsync(int id, Store store, string ETag);
        Task<StoreResponse> DeleteAsync(int id);
        Task<Store> GetAsync(int id);
    }
}
