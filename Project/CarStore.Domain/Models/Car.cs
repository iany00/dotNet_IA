using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using CarStore.Domain.Enums;

namespace CarStore.Domain.Models
{
    public class Car
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
        public User CarHolder { get; set; }
        public int CarManufacturerId { get; set; }
        public CarManufacturer CarManufacturer { get; set; }
        public Store Store { get; set; }
        public IList<CarPhotos> CarPhotos { get; set; }
        public DateTime LastModified { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }

    }

}
