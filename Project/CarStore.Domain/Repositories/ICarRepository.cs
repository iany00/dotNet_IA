using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CarStore.Domain.Models;

namespace CarStore.Domain.Repositories
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> ListAsync(int storeId, CancellationToken token);
        Task AddAsync(Car car);
        Task<Car> FindByIdAsync(int id);

        void Update(Car car);

        void Remove(Car car);
        Task<Car> FindStoreCarAsync(int storeId, int id);
    }
}
