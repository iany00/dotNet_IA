using ParkingLot.Enums;
using ParkingLot.Interfaces;
using ParkingLot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Models
{
    public class ParkingSpaceMapper : IParkingSpaceMapper
    {
        // For each vehicle set parking spot type and number of spaces that occupies
        public ParkingRequirement GetSmallestParkingSpaceRequired(Vehicle vehicle)
        {
            switch (vehicle.vehicleType)
            {
                case VehicleTypes.MotorCycle:
                    return new ParkingRequirement() { 
                        ParkingSpotType = ParkingSpotTypes.Motorcycle, ParkingSpotsCount = 1 
                    };
                
                case VehicleTypes.Car:
                    return new ParkingRequirement() { 
                        ParkingSpotType = ParkingSpotTypes.Compact, ParkingSpotsCount = 1 
                    };
                
                case VehicleTypes.Bus:
                    return new ParkingRequirement() {
                        ParkingSpotType = ParkingSpotTypes.Large, ParkingSpotsCount = 4 
                    };
                
                default:
                    throw new ArgumentException($"vehicleType {vehicle.vehicleType} is invalid.");
            }
        }
    }
}
