﻿using System;
using System.Collections.Generic;
using System.Text;
using CarStore.Domain.Enums;

namespace CarStore.ApiClient.Models
{
    public class CarModel
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
