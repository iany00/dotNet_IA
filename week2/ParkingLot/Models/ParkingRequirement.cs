using ParkingLot.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Models
{
    public class ParkingRequirement
    {
        public ParkingSpotTypes ParkingSpotType { get; set; }
        public int ParkingSpotsCount { get; set; }
    }
}
