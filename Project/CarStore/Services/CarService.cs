using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CarStore.API.Helpers;
using CarStore.API.Resource;
using CarStore.Domain.DataAccess.Repositories;
using CarStore.Domain.Models;
using CarStore.Domain.Repositories;
using CarStore.Domain.Services;
using CarStore.Domain.Services.Communication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarStore.API.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly IStoreRepository _storeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CarService(ICarRepository carRepository, IStoreRepository storeRepository, IUnitOfWork unitOfWork)
        {
            _carRepository = carRepository;
            _storeRepository = storeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Car>> ListAsync(int storeId, CancellationToken token)
        {
            return await _carRepository.ListAsync(storeId, token);
        }

        public async Task<Car> GetAsync(int storeId, int id)
        {
            return await _carRepository.FindStoreCarAsync(storeId, id);
        }

        public async Task<CarResponse> SaveAsync(int storeId, Car car)
        {
            var store = await _storeRepository.FindByIdAsync(storeId);
            if (store == null)
            {
                return new CarResponse("Store not found.");
            }

            car.Store = store;
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


        public async Task<CarResponse> UpdateAsync(int storeId, int id, Car car, string ETag)
        {
            var existingCar = await _carRepository.FindByIdAsync(id);

            var store = await _storeRepository.FindByIdAsync(storeId);
            if (store == null)
            {
                return new CarResponse("Store not found.");
            }

            if (existingCar == null)
            {
                return new CarResponse("Car not Found!");
            }

            if (HashFactory.GetHash(existingCar.LastModified.ToString()) != ETag)
            {
                return new CarResponse("Invalid If-match!");
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
            existingCar.LastModified = DateTime.Now;

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
