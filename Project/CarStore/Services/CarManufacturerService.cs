using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarStore.Domain.Models;
using CarStore.Domain.Repositories;
using CarStore.Domain.Services;
using CarStore.Domain.Services.Communication;

namespace CarStore.API.Services
{
    public class CarManufacturerService : ICarManufacturerService
    {
        private readonly ICarManufacturerRepository _carManufacturerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public CarManufacturerService(ICarManufacturerRepository carManufacturerRepository, IUnitOfWork unitOfWork)
        {
            _carManufacturerRepository = carManufacturerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CarManufacturerResponse> DeleteAsync(int id)
        {
            var carManufacturer = await _carManufacturerRepository.FindByIdAsync(id);
            if (carManufacturer == null)
            {
                return new CarManufacturerResponse("Car Manufacturer not found.");
            }

            _carManufacturerRepository.Remove(carManufacturer);
            await _unitOfWork.CompleteAsync();

            return new CarManufacturerResponse(carManufacturer);

        }

        public async Task<IEnumerable<CarManufacturer>> ListAsync()
        {
            return await _carManufacturerRepository.ListAsync();
        }

        public async Task<CarManufacturerResponse> SaveAsync(CarManufacturer manufacturer)
        {
            try
            {
                await _carManufacturerRepository.AddAsync(manufacturer);
                await _unitOfWork.CompleteAsync();

                return new CarManufacturerResponse(manufacturer);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new CarManufacturerResponse($"An error occurred when saving the car manufacturer: {ex.Message}");
            }
        }

        public async Task<CarManufacturerResponse> UpdateAsync(int id, CarManufacturer manufacturer)
        {
            var existingManufacturer = await _carManufacturerRepository.FindByIdAsync(id);

            if (existingManufacturer == null)
            {
                return new CarManufacturerResponse("Car Manufacturer not found.");
            }

            existingManufacturer.Name = manufacturer.Name;

            try
            {
                _carManufacturerRepository.Update(existingManufacturer);
                await _unitOfWork.CompleteAsync();

                return new CarManufacturerResponse(manufacturer);
            }
            catch (Exception e)
            {
               return new CarManufacturerResponse($"An error occured while updating car manufacturer {e.Message}");
            }

        }
    }
}
