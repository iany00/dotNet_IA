using ParkingLot.Enums;
using ParkingLot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Interfaces
{
    public interface IParkingLot
    {
       // try to park vehicle
        bool ParkVehicle(Vehicle vehicle);

        // un-park vehicle
        bool UnParkvehicle(Vehicle vehicle);

        // Get parking spot for this vehicle type; vehicle may be parked on multiple spots
        List<ParkingSpot> GetOptimalParkingSpot(Vehicle vehicle);

        // Check  parking spot status
        ParkingSpotStatus GetParkingSpotStatus(ParkingSpot spot);
    }
}
