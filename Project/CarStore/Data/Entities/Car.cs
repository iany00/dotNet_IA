using CarStore.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarStore.Data.Entities;

namespace CarStore.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public EngineType EngineType { get; set; }
        public FuelType FuelType { get; set; }
        public SeatsAmountType SeatsAmount { get; set; }
        public TransmissionType TransmissionType { get; set; }
        public string CarHolderId { get; set; }
        public User CarHolder { get; set; }
        public int CarManufacturerId { get; set; }
        public CarManufacturer CarManufacturer { get; set; }
    }

}
