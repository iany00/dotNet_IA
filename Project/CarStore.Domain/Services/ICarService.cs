using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarStore.Domain.Models;
using CarStore.Domain.Services.Communication;

namespace CarStore.Domain.Services
{
    public interface ICarService
    {
        Task<Car> GetAsync(int id);
        Task<IEnumerable<Car>> ListAsync();
        Task<CarResponse> SaveAsync(Car car);

        Task<CarResponse> UpdateAsync(int id, Car car, string ETag);
        Task<CarResponse> DeleteAsync(int id);
    }

}
