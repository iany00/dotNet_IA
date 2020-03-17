using ParkingLot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Interfaces
{
    public interface IParkingSpaceMapper
    {
        // Get the best parking spot for vehicle
        ParkingRequirement GetSmallestParkingSpaceRequired(Vehicle vehicle);
    }
}
