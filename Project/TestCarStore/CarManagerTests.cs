using CarStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CarStore.API.Controllers;
using CarStore.API.Resource;
using CarStore.API.Services;
using CarStore.Domain.Enums;
using CarStore.Domain.Repositories;
using CarStore.Domain.Services.Communication;
using FakeItEasy;
using Xunit;

namespace TestCarStore
{
    public class CarManagerTests
    {
        Car car = new Car()
        {
            Id = 1,
            CarHolderId = 1,
            CarManufacturerId = 1,
            EngineType = EEngineType.V12,
            FuelType = EFuelType.Electricity,
            Model = "model Mock",
            Description = "long desc mock",
            Price = 9999,
            Currency = ECurrency.Dollars,
            SeatsAmount = ESeatsAmountType.Eight,
            TransmissionType = ETransmissionType.Automatic,
            Year = 2020
        };

        [Fact]
        public void CreateCar_ReturnNotNull()
        {
            //arrange
            var uow = A.Fake<IUnitOfWork>();
            var mapper = A.Fake<IMapper>();
            var storeRepository = A.Fake<IStoreRepository>();
            var carRepository = A.Fake<ICarRepository>();

            var carManager = new CarService(carRepository, storeRepository, uow);
            var car = new Car()
            {
                Id = 1,
                CarHolderId = 1,
                CarManufacturerId = 1,
                EngineType = EEngineType.V12,
                FuelType = EFuelType.Electricity,
                Model = "model Mock",
                Description = "long desc mock",
                Price = 9999,
                Currency = ECurrency.Dollars,
                SeatsAmount = ESeatsAmountType.Eight,
                TransmissionType = ETransmissionType.Automatic,
                Year = 2020
            };

            //action
            A.CallTo(() => carRepository.AddAsync(car));

            //assert
            Assert.NotNull(carManager.SaveAsync(1, car));
        }
        
        [Fact]
        public void UpdateCar_ReturnNotEqual()
        {
            var uow = A.Fake<IUnitOfWork>();
            var mapper = A.Fake<IMapper>();
            var storeRepository = A.Fake<IStoreRepository>();
            var carRepository = A.Fake<ICarRepository>();

            var carManager = new CarService(carRepository, storeRepository, uow);

            var updatedCar = new Car()
            {
                CarHolderId = car.CarHolderId,
                CarManufacturerId = car.CarManufacturerId,
                EngineType = car.EngineType,
                FuelType = car.FuelType,
                Model = "updated model Mock",
                Description = car.Description,
                Price = car.Price,
                SeatsAmount = car.SeatsAmount,
                TransmissionType = car.TransmissionType,
                Year = car.Year
            };

            //action
            A.CallTo(() => carRepository.Update(car));

            //assert
            Assert.NotSame(mapper.Map<CarResource>(car), carManager.UpdateAsync(1,1,car,"").Result);
        }
        
        [Fact]
        public void DeleteByIdAsync_ReturnTrue()
        {
            //arrange
            var uow = A.Fake<IUnitOfWork>();
            var storeRepository = A.Fake<IStoreRepository>();
            var carRepository = A.Fake<ICarRepository>();

            var carManager = new CarService(carRepository, storeRepository, uow);

            //action
            A.CallTo(() => carRepository.FindByIdAsync(10)).Returns(car);

            //assert
            Assert.True(carManager.DeleteAsync(10).Result.Success);
        }
        
        [Fact]
        public void DeleteByIdAsync_InvalidCarId_ReturnFalse()
        {
            //arrange
            var uow = A.Fake<IUnitOfWork>();
            var storeRepository = A.Fake<IStoreRepository>();
            var carRepository = A.Fake<ICarRepository>();

            var carManager = new CarService(carRepository, storeRepository, uow);
            Car notExistingCar = null;

            //action
            A.CallTo(() => carRepository.FindByIdAsync(10)).Returns(notExistingCar);

            //assert
            Assert.False(carManager.DeleteAsync(10).Result.Success);
        }
        
        [Fact]
        public void UpdateAsync_nullCar_ReturnNull()
        {
            //arrange
            var uow = A.Fake<IUnitOfWork>();
            var storeRepository = A.Fake<IStoreRepository>();
            var carRepository = A.Fake<ICarRepository>();

            var carManager = new CarService(carRepository, storeRepository, uow);
            Car nullCar = null;

            //action
            A.CallTo(() => carRepository.FindByIdAsync(car.Id)).Returns(car);

            //assert
            Assert.False(carManager.UpdateAsync(1, 1, nullCar, "").Result.Success);
        }
    }
}
