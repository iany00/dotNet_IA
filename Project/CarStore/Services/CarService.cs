using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarStore.Domain.Models;
using CarStore.Domain.Repositories;
using CarStore.Domain.Services;
using CarStore.Domain.Services.Communication;

namespace CarStore.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CarService(ICarRepository carRepository, IUnitOfWork unitOfWork)
        {
            _carRepository = carRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Car>> ListAsyncTask()
        {
            return await _carRepository.ListAsyncTask();
        }

        public async Task<SaveCarResponse> SaveAsync(Car car)
        {
            try
            {
                await _carRepository.AddAsync(car);
                await _unitOfWork.CompleteAsync();

                return new SaveCarResponse(car);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new SaveCarResponse($"An error occurred when saving the category: {ex.Message}");
            }
        }
    }
}
