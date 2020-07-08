using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarStore.Domain.Models;
using CarStore.Domain.Repositories;
using CarStore.Domain.Services;

namespace CarStore.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            this._carRepository = carRepository;
        }
        public async Task<IEnumerable<Car>> ListAsyncTask()
        {
            return await _carRepository.ListAsyncTask();
        }
    }
}
