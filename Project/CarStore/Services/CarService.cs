using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CarStore.API.Resource;
using CarStore.Domain.Models;
using CarStore.Domain.Repositories;
using CarStore.Domain.Services;
using CarStore.Domain.Services.Communication;

namespace CarStore.API.Services
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

        public async Task<IEnumerable<Car>> ListAsync()
        {
            return await _carRepository.ListAsync();
        }

        public async Task<CarResponse> SaveAsync(Car car)
        {
            try
            {
                await _carRepository.AddAsync(car);
                await _unitOfWork.CompleteAsync();

                return new CarResponse(car);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new CarResponse($"An error occurred when saving the car: {ex.Message}");
            }
        }


        public async Task<CarResponse> UpdateAsync(int id, Car car)
        {
            var existingCar = await _carRepository.FindByIdAsync(id);

            if (existingCar == null)
            {
                return new CarResponse("Car not Found!");
            }

            // TODO: how do I fill all the fields at once?
            existingCar.Model = car.Model;
            existingCar.Year = car.Year;
            existingCar.Currency = car.Currency;
            existingCar.Description = car.Description;
            existingCar.EngineType = car.EngineType;
            existingCar.FuelType = car.FuelType;
            existingCar.SeatsAmount = car.SeatsAmount;
            existingCar.TransmissionType = car.TransmissionType;
            existingCar.CarHolderId = car.CarHolderId;
            existingCar.CarManufacturerId = car.CarManufacturerId;

            try
            {
                _carRepository.Update(existingCar);
                await _unitOfWork.CompleteAsync();

                return new CarResponse(car);

            }
            catch (Exception e)
            {
                return new CarResponse($"An error occured when updating the category: {e.Message}");
            }
        }

        public async Task<CarResponse> DeleteAsync(int id)
        {
            var existingCar = await _carRepository.FindByIdAsync(id);

            if (existingCar == null)
            {
                return new CarResponse("Car not found.");
            }

            try
            {
                _carRepository.Remove(existingCar);
                await _unitOfWork.CompleteAsync();

                return new CarResponse(existingCar);
            }
            catch (Exception e)
            {
                return new CarResponse($"An error occured when deleting the Car: {e.Message}");
            }
        }
    }
}
