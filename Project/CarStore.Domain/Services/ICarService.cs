using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CarStore.Domain.Models;
using CarStore.Domain.Services.Communication;

namespace CarStore.Domain.Services
{
    public interface ICarService
    {
        Task<Car> GetAsync(int storeId, int id);
        Task<IEnumerable<Car>> ListAsync(int storeId, CancellationToken token);
        Task<CarResponse> SaveAsync(int storeId, Car car);

        Task<CarResponse> UpdateAsync(int storeId, int id, Car car, string ETag);
        Task<CarResponse> DeleteAsync(int id);
    }

}
