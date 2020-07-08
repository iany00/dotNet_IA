using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CarStore.Domain.Enums;

namespace CarStore.Resource
{
    public class SaveCarResource
    {
        [Required]
        [MaxLength(30)]
        public string Model { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public ECurrency Currency { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public EEngineType EngineType { get; set; }
        [Required]
        public EFuelType FuelType { get; set; }
        [Required]
        public ESeatsAmountType SeatsAmount { get; set; }
        [Required]
        public ETransmissionType TransmissionType { get; set; }
        
        public int CarHolderId { get; set; }
        [Required]
        public int CarManufacturerId { get; set; }
    }
}
