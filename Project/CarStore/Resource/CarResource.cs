﻿using CarStore.Domain.Enums;

namespace CarStore.API.Resource
{
    public class CarResource
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public ECurrency Currency { get; set; }
        public string Description { get; set; }
        public EEngineType EngineType { get; set; }
        public EFuelType FuelType { get; set; }
        public ESeatsAmountType SeatsAmount { get; set; }
        public ETransmissionType TransmissionType { get; set; }
        public int CarHolderId { get; set; }
        public int CarManufacturerId { get; set; }
    }
}
