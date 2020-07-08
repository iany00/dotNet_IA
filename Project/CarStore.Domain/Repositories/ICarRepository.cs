using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarStore.Domain.Models;

namespace CarStore.Domain.Repositories
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> ListAsyncTask();
        Task AddAsync(Car car);
    }
}
