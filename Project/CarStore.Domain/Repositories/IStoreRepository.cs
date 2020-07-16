using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CarStore.Domain.Models;

namespace CarStore.Domain.Repositories
{
    public interface IStoreRepository
    {
        Task<IEnumerable<Store>> ListAsync();
        Task AddAsync(Store store);
        Task<Store> FindByIdAsync(int id);

        void Update(Store store);

        void Remove(Store store);
    }
}
