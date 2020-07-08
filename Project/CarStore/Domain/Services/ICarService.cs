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
        Task<IEnumerable<Car>> ListAsyncTask();
        Task<SaveCarResponse> SaveAsync(Car car);
    }

}
