using ParkingLot.Enums;
using ParkingLot.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot.Models
{
    class ParkingLot : IParkingLot
    {
        public Dictionary<int, ParkingLevel> parkingLot;
        protected ParkingSpaceMapper parkingSpaceMapper;
        protected ParkingLotStatus parkingLotStatus;

      
        public ParkingLot(Dictionary<int, ParkingLevel> parkingLot)
        {
            this.parkingLot = parkingLot;
            
            foreach (KeyValuePair<int, ParkingLevel> level in this.parkingLot)
            {
                foreach (ParkingSpot spot in level.Value)
                {
                    parkingLotStatus.AddFreeSpot(spot);
                }
            }
        }

        public bool ParkVehicle(Vehicle vehicle)
        {
            // Check if is already parked
            if (this.parkingLotStatus.OccupiedSpot.ContainsKey(vehicle.VehicleNumber))
            {
                throw new InvalidOperationException($"Vehicle with number {vehicle.VehicleNumber} is already parked");
            }

            // Get the best empty spot
            parkingLotStatus.GetFreeSpot();
            

            // Throw exception if no spot available

            // remove spot from free spot list

            // Park vehicle to spot


            return true;
        }

        public bool UnParkvehicle(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public ParkingSpot GetOptimalParkingSpot(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public ParkingSpotStatus GetParkingSpotStatus(ParkingSpot spot)
        {
            throw new NotImplementedException();
        }   
    }
}
