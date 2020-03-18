using ParkingLot.Enums;
using ParkingLot.Interfaces;
using ParkingLot.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot
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

        // Park vehicle
        public bool ParkVehicle(Vehicle vehicle)
        {
            // Check if is already parked
            if (this.parkingLotStatus.OccupiedSpot.ContainsKey(vehicle.VehicleNumber))
            {
                throw new InvalidOperationException($"Vehicle with number {vehicle.VehicleNumber} is already parked");
            }

            // Get the best empty spot
            List<ParkingSpot> requriedParkingSpot = GetOptimalParkingSpot(vehicle);
            
            // Throw exception if no spot available
            if(requriedParkingSpot == null)
            {
                throw new InvalidOperationException($"No space found for this vehicle with number {vehicle.VehicleNumber}");
            }

            // Park vehicle; vehicle may occupy multiple spots
            foreach (ParkingSpot spot in requriedParkingSpot)
            {
                // Occupy spot
                parkingLotStatus.OccupySpot(vehicle.VehicleNumber, spot);
            }

            return true;
        }

        public bool UnParkvehicle(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }


        /**
         * 
         */
        public List<ParkingSpot> GetOptimalParkingSpot(Vehicle vehicle)
        {
            // Get vehicle requiremets
            ParkingRequirement parkingVehicleRequriement = this.parkingSpaceMapper.GetSmallestParkingSpaceRequired(vehicle);

            if (parkingLotStatus.FreeSpots.Capacity < parkingVehicleRequriement.ParkingSpotsCount)
            {
                return null;
            }

            List<ParkingSpot> requiredSpotsFind = new List<ParkingSpot>();

            // Get spot by number of spaces
            if (parkingVehicleRequriement.ParkingSpotsCount == 1)
            {
                foreach (var spot in parkingLotStatus.FreeSpots)
                {
                    if (spot.ParkingSpotTypes == parkingVehicleRequriement.ParkingSpotType)
                    {
                        requiredSpotsFind.Add(spot);
                    }
                }
            }
            else
            {
                // Find consecutive required spots
                int freeSpotCount = parkingLotStatus.FreeSpots.Count;
                for (var index = 0; index < freeSpotCount; index++)
                {
                    if (parkingLotStatus.FreeSpots[index].ParkingSpotTypes == parkingVehicleRequriement.ParkingSpotType)
                    {
                        List<ParkingSpot> temporarySpotFind = new List<ParkingSpot>();
                        temporarySpotFind.Add(parkingLotStatus.FreeSpots[index]);

                        for (int i = 1; i <= parkingVehicleRequriement.ParkingSpotsCount; i++)
                        {
                            ParkingSpot nextFreeSpot = parkingLotStatus.FreeSpots[index + i];
                            if (nextFreeSpot.ParkingSpotTypes == parkingVehicleRequriement.ParkingSpotType)
                            {
                                temporarySpotFind.Add(nextFreeSpot);
                            }
                            else
                            {
                                // Next spot is different type;
                                // Empty temporary spot find
                                temporarySpotFind = null;
                                continue;
                            }
                        }
                        requiredSpotsFind = temporarySpotFind;
                    }
                }
            }
            return requiredSpotsFind;
        }


        public ParkingSpotStatus GetParkingSpotStatus(ParkingSpot spot)
        {
            return spot.status;
        }   
    }
}
