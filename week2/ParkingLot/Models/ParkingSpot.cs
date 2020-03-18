using ParkingLot.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Models
{
    public class ParkingSpot
    {
        public int Floor { get; set; }
        public ParkingSpotStatus status { get; set; }
        public int SpotCount { get; set; }
        public ParkingSpotTypes ParkingSpotTypes { get; set; }

        internal static IEnumerator<ParkingSpot> GetEnumerator()
        {
            return ParkingSpot.GetEnumerator();
        }
    }
}
