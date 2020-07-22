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
        public void GetCarById_ReturnCar()
        {
            //arrange
            var uow = A.Fake<IUnitOfWork>();
            var mapper = A.Fake<IMapper>();
            var storeRepository = A.Fake<IStoreRepository>();
            var carRepository = A.Fake<ICarRepository>();

            var carManager = new CarService(carRepository, storeRepository, uow);

            //action
            A.CallTo(() => carRepository.FindByIdAsync(1)).Returns(car);

            //assert
            Assert.Equal(mapper.Map<Car>(car), carManager.GetAsync(1,1).Result);
        }

       /* [Fact]
        public void CreateCar_ReturnNotNull()
        {
            //arrange
            var uow = A.Fake<IUnitOfWork>();
            var mapper = A.Fake<IMapper>();

            var carManager = new CarManager(uow, mapper);
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
            A.CallTo(() => uow.CarRepo.CreateAsync(car)).Returns(car);

            //assert
            Assert.NotNull(carManager.CreateAsync(mapper.Map<CarDto>(car)));
        }

        [Fact]
        public void UpdateCar_ReturnNotEqual()
        {
            //arrange
            var uow = A.Fake<IUnitOfWork>();
            var mapper = A.Fake<IMapper>();

            var carManager = new CarManager(uow, mapper);

            var updatedCar = new Car()
            {
                Id = 1,
                CarHolderId = car.CarHolderId,
                CarManufacturerId = car.CarManufacturerId,
                DriveTrainType = car.DriveTrainType,
                EngineType = car.EngineType,
                FuelType = car.FuelType,
                EngineVolume = car.EngineVolume,
                Model = "updated model Mock",
                LongDescription = car.LongDescription,
                Price = car.Price,
                SeatsAmount = car.SeatsAmount,
                SpeedsAmount = car.SpeedsAmount,
                ShortDescription = car.ShortDescription,
                TransmissionType = car.TransmissionType,
                Year = car.Year
            };

            //action
            A.CallTo(() => uow.CarRepo.UpdateAsync(car)).Returns(updatedCar);

            //assert
            Assert.NotSame(mapper.Map<CarDto>(car), carManager.UpdateAsync(mapper.Map<CarDto>(car)).Result);
        }

        [Fact]
        public void DeleteByIdAsync_ReturnTrue()
        {
            //arrange
            var uow = A.Fake<IUnitOfWork>();
            var mapper = A.Fake<IMapper>();

            var carManager = new CarManager(uow, mapper);

            //action
            A.CallTo(() => uow.CarRepo.GetById(10)).Returns(car);

            //assert
            Assert.True(carManager.DeleteByIdAsync(10).Result.Succeeded);
        }

        [Fact]
        public void DeleteByIdAsync_InvalidCarId_ReturnFalse()
        {
            //arrange
            var uow = A.Fake<IUnitOfWork>();
            var mapper = A.Fake<IMapper>();

            var carManager = new CarManager(uow, mapper);
            Car notExistingCar = null;

            //action
            A.CallTo(() => uow.CarRepo.GetById(10)).Returns(notExistingCar);

            //assert
            Assert.False(carManager.DeleteByIdAsync(10).Result.Succeeded);
        }

        [Fact]
        public void UpdateAsync_nullCarDto_ReturnNull()
        {
            //arrange
            var uow = A.Fake<IUnitOfWork>();
            var mapper = A.Fake<IMapper>();
            var carManager = new CarManager(uow, mapper);
            CarDto nullCarDto = null;

            //action
            A.CallTo(() => uow.CarRepo.GetById(car.Id)).Returns(car);

            //assert
            Assert.Null(carManager.UpdateAsync(nullCarDto).Result);
        }*/
    }
}
